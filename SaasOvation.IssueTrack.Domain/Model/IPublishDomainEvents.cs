using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaasOvation.IssueTrack.Domain.Model
{
    public interface IPublishDomainEvents
    {
        void DefectReported(TenantId Tenant, ProductId Product, IssueId Id, string Name, string Description,IssueAssignerId assigner);
        void FeatureRequested(TenantId Tenant, ProductId Product, IssueId Id, string Name, string Description, IssueAssignerId assigner);
    }
}
