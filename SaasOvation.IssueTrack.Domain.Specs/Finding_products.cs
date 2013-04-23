using Microsoft.VisualStudio.TestTools.UnitTesting;
using SaasOvation.IssueTrack.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaasOvation.IssueTrack.Domain.Specs
{
    [TestMethod]
    public class Finding_products
    {
        IQueryProducts SUT;

        [TestInitialize]
        void Init()
        {
            SUT = new ProductCatalog();    
        }

        [TestMethod]
        void Find_product_by_id()
        {
            
        }

        [TestMethod]
        void Find_product_by_name()
        {
        }

        [TestMethod]
        void Find_product_by_description()
        { 
        }
    }
}
