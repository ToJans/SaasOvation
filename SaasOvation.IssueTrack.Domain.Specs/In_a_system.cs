using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SaasOvation.IssueTrack.Domain.Model;

namespace SaasOvation.IssueTrack.Domain.Specs
{
    public abstract class In_a_system
    {
        public IHandleDomainCommands When;
        public IModifyProductState Given_products;
        public Mock<IPublishDomainEvents> Expect_domainevents;
        public Mock<IModifyProductState> Expect_products;
        
        public void Setup_the_SUT()
        {
            var state = new ProductState();
            Given_products = state;
            When = new Product(state);
            Expect_products = Mock.Of<IModifyProductState> {};
        }

        static void Info(string format, params object[] pars)
        {
            System.Diagnostics.Trace.WriteLine(string.Format(format, pars));
        }


        public class ProxyForProductState: IModifyProductState 
        {
            IModifyProductState ProxiedInstance;

            public ProxyForProductState(IModifyProductState ProductState) {
                ProxiedInstance = ProductState;
            }

            void ProductActivated(TenantId Tenant, ProductId Id, string Name, string Description)
            {
                Info("Activated the product {0} with the name {1}", Id, Name);
                ProxiedInstance.ProductActivated(Tenant, Id, Name, Description);
            }

            void IssueRegistered(TenantId Tenant, ProductId Product, IssueId Id, string Name, string Description, IssueType Type, IssueAssignerId assigner)
            {
                Info("Registered an issue for the product {0} of type {1} with id {2} named {3}",Product,Type,Id,Name);
                ProxiedInstance.IssueRegistered(Tenant, Product, Id, Name, Description, Type, assigner);
            }

            void IssueClosed(TenantId Tenant, ProductId Product, IssueId Id)
            {
                Info("Closed issue {0} for product {1}", Id, Product);
                ProxiedInstance.IssueClosed(Tenant, Product, Id);
            }
        }
    }
}
