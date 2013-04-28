using System;
using System.Collections.Generic;
using System.Linq;

namespace SaasOvation.IssueTrack.Domain.Model.Products
{

    public class State:Issues.State,IModifyState, IQueryState,Issues.IModifyState 
    {
        public State(IPublishEvents bus):base(bus)
        {
            this.Bus = bus;
        }

        List<Tenants.Id> ActiveTenants = new List<Tenants.Id>();
        List<View> RegisteredProducts = new List<View>();
        List<Tuple<Tenants.Id, IssueAssigners.Id>> Assigners = new List<Tuple<Tenants.Id, IssueAssigners.Id>>();
        IPublishEvents Bus;


        public void ProductActivated(Tenants.Id TenantId, Id Id, string a_product_name, string a_product_description)
        {
            RegisteredProducts.Add(new View { Id = Id, TenantId = TenantId });
        }

        public bool ProductExists(Tenants.Id TenantId, Id Id)
        {
            return RegisteredProducts.Any(x => x.TenantId == TenantId && x.Id == Id);
        }

        public bool IsActive(Tenants.Id TenantId, Id ProductId = null)
        {
            if (!ActiveTenants.Contains(TenantId)) return false;
            if (ProductId == null) return true; 
            var prod = GetById(TenantId,ProductId);
            return (prod != null);
        }


        public View GetById(Tenants.Id a_tenant_id, Id a_product_id)
        {
            return this.RegisteredProducts.FirstOrDefault(x=>x.TenantId == a_tenant_id && x.Id == a_product_id);
        }

        public void TenantActivated(Tenants.Id a_tenant_id)
        {
            ActiveTenants.Add(a_tenant_id);
        }


        public bool IsActive(Tenants.Id TenantId, IssueAssigners.Id assignerId)
        {
            if (!ActiveTenants.Contains(TenantId)) return false;
            return Assigners.Any(x=>x.Item1 == TenantId && x.Item2 == assignerId);
        }


        public void IssueAssignerActivated(Tenants.Id a_tenant, IssueAssigners.Id an_assigner)
        {
            Assigners.Add(Tuple.Create(a_tenant, an_assigner));
        }
    }
}
