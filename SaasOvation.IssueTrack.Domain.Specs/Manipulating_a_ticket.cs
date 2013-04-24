using Microsoft.VisualStudio.TestTools.UnitTesting;
using SaasOvation.IssueTrack.Domain.Model;
using Shouldly;
using System;

namespace SaasOvation.IssueTrack.Domain
{
    [TestClass]
    public class Manipulating_a_ticket
    {
        Product SUT;
        TenantId a_tenant = new TenantId(Guid.NewGuid());
        ProductId a_product=new ProductId(Guid.NewGuid());
        TicketId a_feature=new TicketId(Guid.NewGuid());

        string a_product_name = "SaasOvational";
        string a_product_description = "Are you talkin' to me?";

        string a_feature_name="I would like to see the Lion King movie when I press Alt-F4";
        string a_feature_description="Hakuna matata";

        ProductState ProductState;
        TicketState TicketState;

        [TestMethod]
        public void Request_a_feature()
        {
            Setup_the_SUT_and_activate_the_product();

            SUT.RequestFeature(a_tenant,a_product,a_feature,a_feature_name,a_feature_description);

            var result = TicketState.GetById(a_tenant,a_product,a_feature);
            result.Id.ShouldBe(a_feature);
            result.Name.ShouldBe(a_feature_name);
            result.Description.ShouldBe(a_feature_description);
        }

        void Setup_the_SUT_and_activate_the_product()
        {
            ProductState = new ProductState();
            TicketState = new TicketState();

            SUT = new Product(ProductState, ProductState, TicketState, TicketState);

            ProductState.TenantActivated(a_tenant);
            ProductState.ProductActivated(a_tenant, a_product, a_product_name, a_product_description);
        }


    }
}
