using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using Moq;

namespace SaasOvation.IssueTrack.Domain.Specs
{
    [TestClass]
    public class Product_commands
    {
        Model.Products.IHandleCommands SUT;
        Model.Products.State State;
        Mock<Model.Products.IPublishEvents> ProductEventPublisherMock;

        Model.Tenants.Id a_tenant_id = new Model.Tenants.Id(Guid.NewGuid());
        Model.Products.Id a_product_id = new Model.Products.Id(Guid.NewGuid());
        string a_product_name = "Zee product";
        string a_product_description = "Zee description";

        Model.Tenants.Id another_tenant_id = new Model.Tenants.Id(Guid.NewGuid());
        Model.Products.Id another_product_id = new Model.Products.Id(Guid.NewGuid());
        string another_product_name = "Another product";
        string another_product_description = "Another description";

        [TestMethod]
        public void Register_a_new_product()
        {
            Setup_the_SUT_and_activate_the_tenants();
        
            SUT.ActivateProduct(a_tenant_id,a_product_id, a_product_name,a_product_description);
            
            State.IsActive(a_tenant_id, a_product_id).ShouldBe(true);
        }

        [TestMethod]
        public void Registering_2_products()
        {
            Setup_the_SUT_and_activate_the_tenants();
        
            SUT.ActivateProduct(a_tenant_id, a_product_id, a_product_name, a_product_description);
            SUT.ActivateProduct(another_tenant_id, another_product_id, another_product_name, another_product_description);

            State.IsActive(a_tenant_id, a_product_id).ShouldBe(true);
            State.IsActive(another_tenant_id, another_product_id).ShouldBe(true);
        }

        [TestMethod, ExpectedException(typeof(InvalidOperationException))]
        public void Registering_a_product_twice_should_fail()
        {
            Setup_the_SUT_and_activate_the_tenants();

            SUT.ActivateProduct(a_tenant_id, a_product_id, a_product_name, a_product_description);
            SUT.ActivateProduct(a_tenant_id, a_product_id, another_product_name, another_product_description);
        }


        void Setup_the_SUT_and_activate_the_tenants()
        {
            ProductEventPublisherMock = new Mock<Model.Products.IPublishEvents>();

            State = new Model.Products.State(ProductEventPublisherMock.Object);

            SUT = new Model.Products.CommandHandler(State);

            State.TenantActivated(a_tenant_id);
            State.TenantActivated(another_tenant_id);
        }

    }
}
