using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using System;

namespace SaasOvation.IssueTrack.Domain.Specs
{
    [TestClass]
    public class Product_queries
    {
        Model.Products.IQueryState SUT;

        Model.Products.Id a_product_id = new Model.Products.Id(Guid.NewGuid());
        Model.Tenants.Id a_tenant_id = new Model.Tenants.Id(Guid.NewGuid());
        string a_product_name = "Zee product";
        string a_product_description = "Zee description";

        Model.Products.Id another_product_id = new Model.Products.Id(Guid.NewGuid());
        Model.Tenants.Id another_tenant_id = new Model.Tenants.Id(Guid.NewGuid());
        string another_product_name = "Another product";
        string another_product_description = "Another description";


        [TestInitialize]
        public void Init()
        {
            var state = new Model.Products.State(null);    
            SUT= state;

            state.ProductActivated(a_tenant_id, a_product_id, a_product_name, a_product_description);
            state.ProductActivated(another_tenant_id, another_product_id, another_product_name, another_product_description);
        }

        [TestMethod]
        public void Get_a_product_by_id()
        {
            var result = SUT.GetById(a_tenant_id,a_product_id);
            result.Id.ShouldBe(a_product_id);
            result.TenantId.ShouldBe(a_tenant_id);
        }

        [TestMethod]
        public void Get_a_product_by_id_that_does_not_exist()
        {
            var a_non_existing_product = new Model.Products.Id(Guid.NewGuid());
            var result = SUT.GetById(a_tenant_id,a_non_existing_product);
            result.ShouldBe(null);
        }

    }
}
