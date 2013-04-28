using System;
using System.Collections.Generic;
using System.Linq;

namespace SaasOvation.IssueTrack.Domain.Model.Issues
{
    public class State : IModifyState, IQueryState
    {
        List<View> Issues = new List<View>();
        private Products.IPublishEvents ProductEvents;

        public State(Products.IPublishEvents ProductEvents)
        {
            this.ProductEvents = ProductEvents;
        }

        public View GetById(Tenants.Id Tenant, Products.Id Product, Id TicketId)
        {
            return Issues.FirstOrDefault(x => x.Id == TicketId);
        }

        public bool IsActive(Tenants.Id tenant, Products.Id product, Id issue)
        {
            return Issues.Any(x => x.Id == issue);
        }

        public void IssueRegistered(Tenants.Id Tenant, Products.Id Product, Id Id, string Name, string Description, IssueType Type, IssueAssigners.Id assigner)
        {
            Issues.Add(new View { Id = Id, Name = Name, Description = Description, Assigner = assigner });
            if (Type == IssueType.Defect)
                ProductEvents.DefectReported(Tenant, Product, Id, Name, Description, assigner);
            else
                ProductEvents.FeatureRequested(Tenant, Product, Id, Name, Description, assigner);
        }

        public void IssueClosed(Tenants.Id Tenant, Products.Id Product, Id Id)
        {
            throw new NotImplementedException();
        }
    }
}
