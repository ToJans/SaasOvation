using System;
using System.Collections.Generic;
using System.Linq;

namespace SaasOvation.IssueTrack.Domain.Model
{
    public class IssueState : IModifyIssueState, IQueryIssueState
    {
        List<IssueView> Issues = new List<IssueView>();
        private IPublishDomainEvents Bus;

        public IssueState(IPublishDomainEvents bus)
        {
            this.Bus = bus;
        }

        public IssueView GetById(TenantId Tenant, ProductId Product, IssueId TicketId)
        {
            return Issues.FirstOrDefault(x => x.Id == TicketId);
        }

        public bool IsActive(TenantId tenant, ProductId product, IssueId issue)
        {
            return Issues.Any(x => x.Id == issue);
        }

        public void IssueRegistered(TenantId Tenant, ProductId Product, IssueId Id, string Name, string Description, IssueType Type, IssueAssignerId assigner)
        {
            Issues.Add(new IssueView { Id = Id, Name = Name, Description = Description, Assigner = assigner });
            if (Type == IssueType.Defect)
                Bus.DefectReported(Tenant, Product, Id, Name, Description, assigner);
            else
                Bus.FeatureRequested(Tenant, Product, Id, Name, Description, assigner);
        }

        public void IssueClosed(TenantId Tenant, ProductId Product, IssueId Id)
        {
            throw new NotImplementedException();
        }
    }
}
