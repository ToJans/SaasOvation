using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SaasOvation.IssueTrack.Domain.Model;

namespace SaasOvation.IssueTrack.Domain.Specs
{

    [TestClass]
    public class Manipulating_a_product
    {
        IHandleProductCommands SUT;
        

        [TestInitialize]
        public void Init()
        {
            var state = new ProductState();
            SUT = new Product(state,state);
        }

        ProductId a_product_id = new ProductId(Guid.NewGuid());
        TenantId a_tenant_id = new TenantId(Guid.NewGuid());
        string a_product_name = "Zee product";
        string a_product_description = "Zee description";

        ProductId another_product_id = new ProductId(Guid.NewGuid());
        TenantId another_tenant_id = new TenantId(Guid.NewGuid());
        string another_product_name = "Another product";
        string another_product_description = "Another description";

        [TestMethod]
        public void Register_a_new_product()
        {
            SUT.RegisterProduct(a_product_id, a_tenant_id, a_product_name,a_product_description);
        }

        [TestMethod]
        public void Registering_2_products()
        {
            SUT.RegisterProduct(a_product_id, a_tenant_id, a_product_name, a_product_description);
            SUT.RegisterProduct(another_product_id, another_tenant_id, another_product_name, another_product_description);
        }

        [TestMethod, ExpectedException(typeof(InvalidOperationException))]
        public void Registering_a_product_with_the_same_id_should_fail()
        {
            SUT.RegisterProduct(a_product_id, a_tenant_id, a_product_name, a_product_description);
            SUT.RegisterProduct(a_product_id, another_tenant_id, another_product_name, another_product_description);
        }
    }
}
