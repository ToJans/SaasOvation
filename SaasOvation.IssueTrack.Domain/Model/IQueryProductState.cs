namespace SaasOvation.IssueTrack.Domain.Model
{
    public interface IQueryProductState:IQueryIssueState 
    {
        bool ProductExists(TenantId tenant, ProductId Product);

        bool IsActive(TenantId tenant, ProductId product=null);

        ProductView GetById(TenantId a_tenant_id, ProductId a_product_id);

        bool IsActive(TenantId tenant, IssueAssignerId assigner);
    }
}
