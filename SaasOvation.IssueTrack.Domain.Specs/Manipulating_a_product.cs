using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SaasOvation.IssueTrack.Domain.Model;
using Shouldly;
using Moq;

namespace SaasOvation.IssueTrack.Domain.Specs
{
    [TestClass]
    public class Manipulating_a_product:In_a_system_with_some_active_tenants
    {
        [TestMethod]
        public void Register_a_new_product()
        {
            Setup_the_SUT();

            When.ActivateProduct(a_tenant, a_product, a_product_name, a_product_description);
            
            For_products.Verify(x=>x.ProductActivated(a_tenant,a_product,a_product_name,a_product_description));
        }

        [TestMethod]
        public void Registering_2_products()
        {
            Setup_the_SUT();
            Products.ProductActivated(a_tenant, a_product, a_product_name, a_product_description);

            When.ActivateProduct(another_tenant, another_product, another_product_name, another_product_description);

            For_products.Verify(x => x.ProductActivated(a_tenant, a_product, a_product_name, a_product_description));
            For_products.Verify(x => x.ProductActivated(another_tenant, another_product, another_product_name, another_product_description));
        }

        [TestMethod, ExpectedException(typeof(InvalidOperationException))]
        public void Registering_a_product_twice_should_fail()
        {
            Setup_the_SUT();
            Products.ProductActivated(a_tenant, a_product, a_product_name, a_product_description);

            When.ActivateProduct(a_tenant, a_product, another_product_name, another_product_description);
        }
    }
}
