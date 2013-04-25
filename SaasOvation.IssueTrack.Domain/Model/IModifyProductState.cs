namespace SaasOvation.IssueTrack.Domain.Model
{
    public interface IModifyProductState:IModifyIssueState
    {
        void ProductActivated(TenantId Tenant,ProductId Id, string Name, string Description);
    }
}
