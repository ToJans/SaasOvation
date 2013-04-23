using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SaasOvation.IssueTrack.Domain.Model
{
    public interface IHandleProductCommands
    {
        void RegisterProduct(ProductId a_product_id, TenantId a_tenant_id, string a_product_name, string a_product_description);
    }
}
