using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaasOvation.IssueTrack.Domain.Model
{

    public class ProductState:TicketState, IModifyProductState, IQueryProductState
    {
        List<TenantId> ActiveTenants = new List<TenantId>();
        List<ProductView> RegisteredProducts = new List<ProductView>();
        

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
    }
}
