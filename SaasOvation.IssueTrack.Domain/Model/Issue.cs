namespace SaasOvation.IssueTrack.Domain.Model
{
    public class Issue
    {
        public TenantId Tenant { get; set; }
        public ProductId Product { get; set; }
        public IssueId Id { get; set; }
    }
}
