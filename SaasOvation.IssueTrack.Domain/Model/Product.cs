using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaasOvation.IssueTrack.Domain.Model
{

    public class ProductId : GenericId 
    { 
        protected override string TypeString { get { return "product"; } }

        public ProductId(Guid somevalue) : base(somevalue) { }
    }

    public class Product: IHandleProductCommands
    {
        public void RegisterProduct(ProductId a_product_id, TenantId a_tenant_id, string a_product_name, string a_product_description)
        {
        }
    }
}
