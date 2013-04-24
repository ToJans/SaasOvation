using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaasOvation.IssueTrack.Domain.Model
{

    public class ProductId : GenericId 
    { 
        protected override string TypeString { get { return "product"; } }

        public ProductId(Guid somevalue) : base(somevalue) { }
    }

    public class Product: IHandleProductCommands
    {
        private IModifyProductState Changes;
        private IQueryProductState Queries;

        public Product(ProductState State) : this(State, State) { }

        public Product(IModifyProductState Changes,IQueryProductState Queries) {
            this.Changes = Changes;
            this.Queries = Queries;
        }

        public void ActivateProduct(TenantId Tenant, ProductId Id, string Name, string Description)
        {
            MustBeActive(Tenant);
            Guard.Against(Queries.IsActive(Tenant,Id),"This product is already active.");
            Changes.ProductActivated(Tenant, Id, Name, Description);
        }

        public void RequestFeature(TenantId Tenant, ProductId Product, TicketId Id, string Name, string Description)
        {
            MustBeActive(Tenant,Product);
            Changes.TicketRegistered(Tenant,Product,Id, Name, Description);
            
        }

        public void ReportDefect(TenantId Tenant, ProductId Product, TicketId Id, string Name, string Description)
        {
            throw new NotImplementedException();
        }

        void MustBeActive(TenantId tenant = null, ProductId product = null, TicketId ticket = null)
        {
            if (tenant != null) Guard.That(Queries.IsActive(tenant), "This is an inactive tenant");
            if (product != null) Guard.That(Queries.IsActive(tenant,product), "This is an inactive product");
            if (ticket != null) Guard.That(Queries.IsActive(tenant, product, ticket), "This is an inactive ticket");
        }
    }
}
