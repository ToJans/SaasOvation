namespace SaasOvation.IssueTrack.Domain.Model.Products
{
    public interface IHandleCommands
    {
        void ActivateProduct(Tenants.Id Tenant, Products.Id Id, string Name, string Description);
        void RequestFeature(Tenants.Id Tenant, Products.Id Product, Issues.Id Id, string Name, string Description, IssueAssigners.Id Assigner);
        void ReportDefect(Tenants.Id Tenant, Products.Id Product, Issues.Id Id, string Name, string Description, IssueAssigners.Id Assigner);
    }
}
