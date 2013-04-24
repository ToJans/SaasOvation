using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SaasOvation.IssueTrack.Domain.Model
{
    public interface IQueryIssueState
    {
        IssueView GetById(TenantId Tenant,ProductId Product,IssueId Ticket);

        bool IsActive(TenantId tenant, ProductId product, IssueId ticket);
    }
}
