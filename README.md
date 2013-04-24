# SaasOvation demo DDD implementation

This code is being written during [@VaughnVernon](http://vaughnvernon.co/) 's [#IDDDtour](http://idddtour.com/) in Belgium. It is a very opinionated approach that I will use later on for my presentation. I am quite sure that there are or will be some caveats in this implementation, but the idea is to get you thinking about delaying your infrastructure decisions.

*It should not matter where or how you store your state, if you do respect this approach*

It might look a bit like this:

![That looks painful](http://lh6.ggpht.com/_2VEaTPMR9yw/So8uWIZSPFI/AAAAAAAAAVo/PhxXTpF7bD8/basketball_fail%5B2%5D.jpg?imgmax=800)

... but I found out that the flow is actually pretty nice when you start developing like this ...

## Some context

Due to my more recent experiments with [Erlang](http://www.erlang.org/), I think I might have found a way to model the domain in a way that refactoring does not hurt as much as the more conventional approach, and that it allows you to remove infrastructure completely out of the model.

It looks rather similar to the actor model, and is based on the fact that Erlang actually uses processes that communicate with eachother while respecting OO principles the way they were intended.

In Erlang, while counterintuitive from the perspective of a conventional OO thinker, all OO principles are respected by having processes that communicate through messaging only:

- Dynamic dispatch
- Encapsulation 
- Polymorphism 
- Inheritance
- Open recursion
 
If you see erlang code combined with DDD, there is almost NO infrastructure code there...

## Other implementations

I think it is interesting to see how others implemented this:

- [@yreynhout](https://github.com/yreynhout/IssueTracking)
- [@ONE75](https://github.com/ONE75/IDDD)

Feel free to send a pull request to add your own!

[As Alan Kay points out](http://lists.squeakfoundation.org/pipermail/squeak-dev/1998-October/017019.html), the original focus in OO was not about the state, but about the interactions/messaging between objects.

This implementation is trying to achieve this by applying [CQRS](http://martinfowler.com/bliki/CQRS.html) on a really low level. Some might suggest me to use F# or similar instead, and they might be right.

## Motivation

By doing this, you really postpone the infrastructure decisions to the very end of the solution.
You make everything explicit, and really add an extra (but understandable) layer of explicitness.
One important thing to notice here, is that the Query side really needs to respect the [TDA](http://pragprog.com/articles/tell-dont-ask) principle, in order 
for the domain to be completely detached from the implementation.

This approach is an evolution of the technique used by [@abdullin](https://github.com/Lokad/lokad-iddd-sample/blob/master/Sample/Domain/CustomerAggregate/Customer.cs).

## Code

This is an example, it might not be up to date, so check [here](https://github.com/ToJans/SaasOvation/blob/master/SaasOvation.IssueTrack.Domain/Model/Product.cs) for the latest version.

```c#
    public class Product: IHandleDomainCommands
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

        public void RequestFeature(TenantId Tenant, ProductId Product, IssueId Id, string Name, string Description,IssueAssignerId Assigner)
        {
            MustBeActive(Tenant,Product);
            MustBeActive(Tenant,assigner:Assigner);
            Changes.IssueRegistered(Tenant,Product,Id, Name, Description,IssueType.Feature,Assigner);
        }

        public void ReportDefect(TenantId Tenant, ProductId Product, IssueId Id, string Name, string Description,IssueAssignerId Assigner)
        {
            MustBeActive(Tenant, Product);
            Changes.IssueRegistered(Tenant, Product, Id, Name, Description,IssueType.Defect,Assigner);
        }

        public void CloseIssue(TenantId Tenant, ProductId Product, IssueId Id)
        {
            MustBeActive(Tenant, Product, Id);
            Changes.IssueClosed(Tenant, Product, Id);
        }

        void MustBeActive(TenantId tenant = null, ProductId product = null, IssueId ticket = null,IssueAssignerId assigner=null)
        {
            if (tenant != null) Guard.That(Queries.IsActive(tenant), "This is an inactive tenant");
            if (product != null) Guard.That(Queries.IsActive(tenant,product), "This is an inactive product");
            if (ticket != null) Guard.That(Queries.IsActive(tenant, product, ticket), "This is an inactive ticket");
            if (assigner != null) Guard.That(Queries.IsActive(tenant, assigner), "This is an inactive assigner");
        }
    }
```
