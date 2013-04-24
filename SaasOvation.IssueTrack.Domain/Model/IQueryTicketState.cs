using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SaasOvation.IssueTrack.Domain.Model
{
    public interface IQueryTicketState
    {
        TicketView GetById(TenantId Tenant,ProductId Product,TicketId Ticket);

        bool IsActive(TenantId tenant, ProductId product, TicketId ticket);
    }
}
