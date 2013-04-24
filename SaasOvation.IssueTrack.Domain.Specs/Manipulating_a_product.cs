using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SaasOvation.IssueTrack.Domain.Model;
using Shouldly;

namespace SaasOvation.IssueTrack.Domain.Specs
{

    [TestClass]
    public class Manipulating_a_product
    {
        IHandleProductCommands SUT;
        ProductState ProductState;
        TicketState TicketState;

        TenantId a_tenant_id = new TenantId(Guid.NewGuid());
        ProductId a_product_id = new ProductId(Guid.NewGuid());
        string a_product_name = "Zee product";
        string a_product_description = "Zee description";

        TenantId another_tenant_id = new TenantId(Guid.NewGuid());
        ProductId another_product_id = new ProductId(Guid.NewGuid());
        string another_product_name = "Another product";
        string another_product_description = "Another description";

        [TestMethod]
        public void Register_a_new_product()
        {
            Setup_the_SUT_and_activate_the_tenants();
        
            SUT.ActivateProduct(a_tenant_id,a_product_id, a_product_name,a_product_description);
            
            ProductState.IsActive(a_tenant_id, a_product_id).ShouldBe(true);
        }

        [TestMethod]
        public void Registering_2_products()
        {
            Setup_the_SUT_and_activate_the_tenants();
        
            SUT.ActivateProduct(a_tenant_id, a_product_id, a_product_name, a_product_description);
            SUT.ActivateProduct(another_tenant_id, another_product_id, another_product_name, another_product_description);

            ProductState.IsActive(a_tenant_id, a_product_id).ShouldBe(true);
            ProductState.IsActive(another_tenant_id, another_product_id).ShouldBe(true);
        }

        [TestMethod, ExpectedException(typeof(InvalidOperationException))]
        public void Registering_a_product_with_the_same_id_should_fail()
        {
            Setup_the_SUT_and_activate_the_tenants();

            SUT.ActivateProduct(a_tenant_id, a_product_id, a_product_name, a_product_description);
            SUT.ActivateProduct(a_tenant_id, a_product_id, another_product_name, another_product_description);
        }


        void Setup_the_SUT_and_activate_the_tenants()
        {
            ProductState = new ProductState();
            TicketState = new TicketState();

            SUT = new Product(ProductState, ProductState, TicketState, TicketState);

            ProductState.TenantActivated(a_tenant_id);
            ProductState.TenantActivated(another_tenant_id);
        }

    }
}
