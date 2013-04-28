namespace SaasOvation.IssueTrack.Domain.Model.Products
{
    public interface IQueryState:Issues.IQueryState 
    {
        bool ProductExists(Tenants.Id tenant, Id Product);

        bool IsActive(Tenants.Id tenant, Id product = null);

        View GetById(Tenants.Id a_tenant_id, Id a_product_id);

        bool IsActive(Tenants.Id tenant, IssueAssigners.Id assigner);
    }
}
