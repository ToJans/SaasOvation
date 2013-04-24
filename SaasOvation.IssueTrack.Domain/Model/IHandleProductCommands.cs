using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SaasOvation.IssueTrack.Domain.Model
{
    public interface IHandleProductCommands
    {
        void ActivateProduct(TenantId Tenant,ProductId Id, string Name, string Description);
        void RequestFeature(TenantId Tenant,ProductId Product,TicketId Id,string Name,string Description);
        void ReportDefect(TenantId Tenant, ProductId Product, TicketId Id, string Name, string Description);
    }
}
