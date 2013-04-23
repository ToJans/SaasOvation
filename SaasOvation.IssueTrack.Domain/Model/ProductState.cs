using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaasOvation.IssueTrack.Domain.Model
{


    public class ProductState : IModifyProductState, IQueryProducts
    {
        List<ProductView> RegisteredProducts = new List<ProductView>();

        public void ProductRegistered(ProductId Id, TenantId TenantId, string a_product_name, string a_product_description)
        {
            RegisteredProducts.Add(new ProductView { Id = Id, TenantId = TenantId });
        }

        public bool ProductExists(ProductId Id)
        {
            return RegisteredProducts.Any(x => x.Id == Id);
        }


        public IEnumerable<ProductView> FindById(ProductId Id)
        {
            return RegisteredProducts.Where(x => x.Id == Id);
        }

        public ProductView GetById(ProductId Id)
        {
            return RegisteredProducts.FirstOrDefault(x => x.Id == Id);
        }

    }
}
