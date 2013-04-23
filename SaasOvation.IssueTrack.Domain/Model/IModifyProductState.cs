using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SaasOvation.IssueTrack.Domain.Model
{
    public interface IModifyProductState
    {
        void ProductRegistered(ProductId Id, TenantId TenantId, string a_product_name, string a_product_description);
    }
}
