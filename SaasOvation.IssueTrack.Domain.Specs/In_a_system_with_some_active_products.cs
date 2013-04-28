using SaasOvation.IssueTrack.Domain.Model;
using System;

namespace SaasOvation.IssueTrack.Domain.Specs
{
    public abstract class In_a_system_with_some_active_products:In_a_system_with_some_active_tenants
    {
        public IssueAssignerId an_assigner = new IssueAssignerId(Guid.NewGuid());

        public IssueId a_feature = new IssueId(Guid.NewGuid());
        public string a_feature_name = "I would like to see the Lion King movie when I press Alt-F4";
        public string a_feature_description = "Hakuna matata";

        public IssueId a_defect = new IssueId(Guid.NewGuid());
        public string a_defect_name = "Do not show the Lion King movie when I press return";
        public string a_defect_description = "Say WHUT?";

        public new void Setup_the_SUT()
        {
            base.Setup_the_SUT();
          
            Products.ProductActivated(a_tenant, a_product, a_product_name, a_product_description);
        }
    }
}
