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

        public void ActivateProduct(Tenants.Id Tenant, Id Product, string Name, string Description)
        {
            MustBeActive(Tenant);
            Guard.Against(Queries.IsActive(Tenant,Product),"This product is already active.");
            Changes.ProductActivated(Tenant, Product, Name, Description);
        }

        public void CloseIssue(Tenants.Id Tenant, Products.Id Product, Issues.Id Issue)
        {
            MustBeActive(Tenant, Product, Issue);
            IssueChanges.IssueClosed(Tenant, Product, Issue);
        }

        public void RequestFeature(Tenants.Id Tenant, Id Product, Issues.Id Feature, string Name, string Description, IssueAssigners.Id Assigner)
        {
            MustBeActive(Tenant,Product);
            MustBeActive(Tenant,Assigner:Assigner);
            IssueChanges.IssueRegistered(Tenant,Product,Feature, Name, Description,Issues.IssueType.Feature,Assigner);
        }

        public void ReportDefect(Tenants.Id Tenant, Id Product, Issues.Id Defect, string Name, string Description, IssueAssigners.Id Assigner)
        {
            MustBeActive(Tenant, Product);
            IssueChanges.IssueRegistered(Tenant, Product, Defect, Name, Description, Issues.IssueType.Defect, Assigner);
        }


        void MustBeActive(Tenants.Id Tenant = null, Id Product = null, Issues.Id Issue = null, IssueAssigners.Id Assigner = null)
        {
            if (Tenant != null) Guard.That(Queries.IsActive(Tenant), "This is an inactive tenant");
            if (Product != null) Guard.That(Queries.IsActive(Tenant,Product), "This is an inactive product");
            if (Issue != null) Guard.That(Queries.IsActive(Tenant, Product, Issue), "This is an inactive ticket");
            if (Assigner != null) Guard.That(Queries.IsActive(Tenant, Assigner), "This is an inactive assigner");
        }
    }
}
