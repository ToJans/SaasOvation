using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaasOvation.IssueTrack.Domain.Model
{
    public enum IssueType
    { 
        Defect,
        Feature
    }

    public interface IModifyIssueState
    {
        void IssueRegistered(TenantId Tenant, ProductId Product, IssueId Id, string Name, string Description, IssueType Type,IssueAssignerId assigner);
        void IssueClosed(TenantId Tenant, ProductId Product, IssueId Id);
    }
}
