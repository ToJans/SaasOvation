namespace SaasOvation.IssueTrack.Domain.Model.Issues
{
    public enum IssueType
    { 
        Defect,
        Feature
    }

    public interface IModifyState
    {
        void IssueRegistered(Tenants.Id Tenant, Products.Id Product, Id Id, string Name, string Description, IssueType Type,IssueAssigners.Id assigner);
        void IssueClosed(Tenants.Id Tenant, Products.Id Product, Id Id);
    }
}
