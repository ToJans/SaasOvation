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
        private IModifyProductState ProductChanges;
        private IQueryProductState ProductQueries;
        private IModifyTicketState TicketChanges;
        private IQueryTicketState TicketQueries;

        public Product(
                IModifyProductState ProductChanges,IQueryProductState ProductQueries,
                IModifyTicketState TicketChanges,IQueryTicketState TicketQueries) {
            this.ProductChanges = ProductChanges;
            this.ProductQueries = ProductQueries;
            this.TicketChanges= TicketChanges;
            this.TicketQueries = TicketQueries;
        }

        public void ActivateProduct(TenantId Tenant, ProductId Id, string Name, string Description)
        {
            MustBeActive(Tenant);
            Guard.Against(ProductQueries.IsActive(Tenant,Id),"This product is already active.");
            ProductChanges.ProductActivated(Tenant, Id, Name, Description);
        }

        public void RequestFeature(TenantId Tenant, ProductId Product, TicketId Id, string Name, string Description)
        {
            MustBeActive(Tenant,Product);
            TicketChanges.TicketRegistered(Tenant,Product,Id, Name, Description);
            
        }

        public void ReportDefect(TenantId Tenant, ProductId Product, TicketId Id, string Name, string Description)
        {
            throw new NotImplementedException();
        }

        void MustBeActive(TenantId tenant = null, ProductId product = null, TicketId ticket = null)
        {
            if (tenant != null) Guard.That(ProductQueries.IsActive(tenant), "This is an inactive tenant");
            if (product != null) Guard.That(ProductQueries.IsActive(tenant,product), "This is an inactive product");
            if (ticket != null) Guard.That(TicketQueries.IsActive(tenant, product, ticket), "This is an inactive ticket");
        }




    }
}
