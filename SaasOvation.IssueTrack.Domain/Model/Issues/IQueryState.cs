namespace SaasOvation.IssueTrack.Domain.Model.Issues
{
    public interface IQueryState
    {
        View GetById(Tenants.Id Tenant, Products.Id Product, Id Ticket);

        bool IsActive(Tenants.Id tenant, Products.Id product, Id ticket);
    }
}
