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
            SUT = new Product();
        }

        ProductId a_product_id = new ProductId(Guid.NewGuid());
        TenantId a_tenant_id = new TenantId(Guid.NewGuid());
        string a_product_name = "Zee product";
        string a_product_description = "Zee description";

        [TestMethod]
        public void Register_a_new_product()
        {
            SUT.RegisterProduct(a_product_id, a_tenant_id, a_product_name,a_product_description);
        }

    }
}
