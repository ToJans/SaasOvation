using SaasOvation.Common.Domain.Model;

namespace SaasOvation.IssueTrack.Domain.Model.Products
{
    public class CommandHandler: IHandleCommands
    {
        private IModifyState Changes;
        private IQueryState Queries;
        private Issues.IModifyState IssueChanges;

        public CommandHandler(State State) : this(State, State,State) { }

        public CommandHandler(IModifyState Changes, IQueryState Queries, Issues.IModifyState Issues)
        {
            this.Changes = Changes;
            this.Queries = Queries;
            this.IssueChanges = Issues;
        }

        public void ActivateProduct(Tenants.Id Tenant, Id Id, string Name, string Description)
        {
            MustBeActive(Tenant);
            Guard.Against(Queries.IsActive(Tenant,Id),"This product is already active.");
            Changes.ProductActivated(Tenant, Id, Name, Description);
        }

        public void CloseIssue(Tenants.Id Tenant, Products.Id Product, Issues.Id Id)
        {
            MustBeActive(Tenant, Product, Id);
            IssueChanges.IssueClosed(Tenant, Product, Id);
        }

        public void RequestFeature(Tenants.Id Tenant, Id Product, Issues.Id Id, string Name, string Description, IssueAssigners.Id Assigner)
        {
            MustBeActive(Tenant,Product);
            MustBeActive(Tenant,assigner:Assigner);
            IssueChanges.IssueRegistered(Tenant,Product,Id, Name, Description,Issues.IssueType.Feature,Assigner);
        }

        public void ReportDefect(Tenants.Id Tenant, Id Product, Issues.Id Id, string Name, string Description, IssueAssigners.Id Assigner)
        {
            MustBeActive(Tenant, Product);
            IssueChanges.IssueRegistered(Tenant, Product, Id, Name, Description, Issues.IssueType.Defect, Assigner);
        }


        void MustBeActive(Tenants.Id tenant = null, Id product = null, Issues.Id ticket = null, IssueAssigners.Id assigner = null)
        {
            if (tenant != null) Guard.That(Queries.IsActive(tenant), "This is an inactive tenant");
            if (product != null) Guard.That(Queries.IsActive(tenant,product), "This is an inactive product");
            if (ticket != null) Guard.That(Queries.IsActive(tenant, product, ticket), "This is an inactive ticket");
            if (assigner != null) Guard.That(Queries.IsActive(tenant, assigner), "This is an inactive assigner");
        }
    }
}
