using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaasOvation.IssueTrack.Domain.Model
{
    public class IssueState:IModifyIssueState,IQueryIssueState
    {
        List<IssueView> Issues = new List<IssueView>();

        public IssueState()
        {

        }

        public void RegisterIssue(TenantId Tenant,ProductId Product,IssueId Id,string Name,string Description)
        {
            Issues.Add(new IssueView {Id = Id,Name = Name,Description = Description});
        }


        public IssueView GetById(TenantId Tenant,ProductId Product,IssueId TicketId)
        {
            return Issues.FirstOrDefault(x=>x.Id == TicketId);
        }


        public bool IsActive(TenantId tenant, ProductId product, IssueId issue)
        {
            return Issues.Any(x => x.Id == issue); 
        }

        public void IssueRegistered(TenantId Tenant, ProductId Product, IssueId Id, string Name, string Description,IssueAssignerId assigner)
        {
            Issues.Add(new IssueView {  Id = Id,Name = Name,Description = Description,Assigner = assigner});
        }


        public void IssueClosed(TenantId Tenant, ProductId Product, IssueId Id)
        {
            throw new NotImplementedException();
        }
    }
}
