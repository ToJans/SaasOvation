using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaasOvation.IssueTrack.Domain.Model
{
    public interface IQueryProducts
    {
        bool ProductExists(ProductId a_product_id);

        IEnumerable<ProductView> FindById(ProductId Id);
        ProductView GetById(ProductId Id);
    }
}
