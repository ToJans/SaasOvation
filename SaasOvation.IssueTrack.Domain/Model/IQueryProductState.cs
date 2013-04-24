using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaasOvation.IssueTrack.Domain.Model
{
    public interface IQueryProductState:IQueryTicketState 
    {
        bool ProductExists(TenantId tenant, ProductId Product);

        bool IsActive(TenantId tenant, ProductId product=null);

        ProductView GetById(TenantId a_tenant_id, ProductId a_product_id);
    }
}
