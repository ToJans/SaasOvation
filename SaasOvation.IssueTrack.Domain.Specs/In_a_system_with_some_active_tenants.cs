using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SaasOvation.IssueTrack.Domain.Model;
using System;

namespace SaasOvation.IssueTrack.Domain.Specs
{
    public abstract class In_a_system_with_some_active_tenants:In_a_system
    {
        public TenantId a_tenant = new TenantId(Guid.NewGuid());
        
        public ProductId a_product = new ProductId(Guid.NewGuid());
        public string a_product_name = "Zee product";
        public string a_product_description = "Zee description";

        public TenantId another_tenant = new TenantId(Guid.NewGuid());
        
        public ProductId another_product = new ProductId(Guid.NewGuid());
        public string another_product_name = "Another product";
        public string another_product_description = "Another description";

        public new void Setup_the_SUT()
        {
            base.Setup_the_SUT();
            Products.TenantActivated(a_tenant);
            Products.TenantActivated(another_tenant);
        }
    }
}
