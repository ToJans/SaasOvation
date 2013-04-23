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
        private IModifyProductState Apply;
        private IQueryProducts Query;

        public Product(IModifyProductState Apply,IQueryProducts Query) {
            this.Apply = Apply;
            this.Query = Query;
        }

        public void RegisterProduct(ProductId a_product_id, TenantId a_tenant_id, string a_product_name, string a_product_description)
        {
            Guard.Against(Query.ProductExists(a_product_id),"The product is already registered.");
            Apply.ProductRegistered(a_product_id, a_tenant_id, a_product_name, a_product_description);
        }
    }
}
