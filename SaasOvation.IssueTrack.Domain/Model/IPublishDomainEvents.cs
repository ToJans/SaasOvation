namespace SaasOvation.IssueTrack.Domain.Model
{
    public interface IPublishDomainEvents
    {
        void DefectReported(TenantId Tenant, ProductId Product, IssueId Id, string Name, string Description,IssueAssignerId assigner);
        void FeatureRequested(TenantId Tenant, ProductId Product, IssueId Id, string Name, string Description, IssueAssignerId assigner);
    }
}
