namespace SaasOvation.IssueTrack.Domain.Model.Products
{
    public interface IPublishEvents
    {
        void DefectReported(Tenants.Id Tenant, Id Product, Issues.Id Id, string Name, string Description, IssueAssigners.Id assigner);
        void FeatureRequested(Tenants.Id Tenant, Id Product, Issues.Id Id, string Name, string Description, IssueAssigners.Id assigner);
    }
}
