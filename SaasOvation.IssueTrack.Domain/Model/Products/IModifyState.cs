namespace SaasOvation.IssueTrack.Domain.Model.Products
{
    public interface IModifyState 
    {
        void ProductActivated(Tenants.Id Tenant,Id Id, string Name, string Description);
    }
}
