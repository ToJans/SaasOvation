using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaasOvation.IssueTrack.Domain.Model
{

    public class ProductState:IssueState, IModifyProductState, IQueryProductState
    {
        public ProductState(IPublishDomainEvents bus):base(bus)
        {
            this.Bus = bus;
        }

        List<TenantId> ActiveTenants = new List<TenantId>();
        List<ProductView> RegisteredProducts = new List<ProductView>();
        List<Tuple<TenantId, IssueAssignerId>> Assigners = new List<Tuple<TenantId, IssueAssignerId>>();
        IPublishDomainEvents Bus;
        

        public void ProductActivated(TenantId TenantId, ProductId Id, string a_product_name, string a_product_description)
        {
            RegisteredProducts.Add(new ProductView { Id = Id, TenantId = TenantId });
        }

        public bool ProductExists(TenantId TenantId, ProductId Id)
        {
            return RegisteredProducts.Any(x => x.TenantId == TenantId && x.Id == Id);
        }

        public bool IsActive(TenantId TenantId, ProductId ProductId = null)
        {
            if (!ActiveTenants.Contains(TenantId)) return false;
            if (ProductId == null) return true; 
            var prod = GetById(TenantId,ProductId);
            return (prod != null);
        }


        public ProductView GetById(TenantId a_tenant_id, ProductId a_product_id)
        {
            return this.RegisteredProducts.FirstOrDefault(x=>x.TenantId == a_tenant_id && x.Id == a_product_id);
        }

        public void TenantActivated(TenantId a_tenant_id)
        {
            ActiveTenants.Add(a_tenant_id);
        }


        public bool IsActive(TenantId TenantId, IssueAssignerId assignerId)
        {
            if (!ActiveTenants.Contains(TenantId)) return false;
            return Assigners.Any(x=>x.Item1 == TenantId && x.Item2 == assignerId);
        }


        public void IssueAssignerActivated(TenantId a_tenant, IssueAssignerId an_assigner)
        {
            Assigners.Add(Tuple.Create(a_tenant, an_assigner));
        }
    }
}
