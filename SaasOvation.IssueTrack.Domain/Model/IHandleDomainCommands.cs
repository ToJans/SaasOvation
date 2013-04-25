namespace SaasOvation.IssueTrack.Domain.Model
{
    public interface IHandleDomainCommands
    {
        void ActivateProduct(TenantId Tenant,ProductId Id, string Name, string Description);
        void RequestFeature(TenantId Tenant,ProductId Product,IssueId Id,string Name,string Description,IssueAssignerId Assigner);
        void ReportDefect(TenantId Tenant, ProductId Product, IssueId Id, string Name, string Description, IssueAssignerId Assigner);
    }
}
