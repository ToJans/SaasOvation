using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaasOvation.IssueTrack.Domain.Model
{
    public class TicketState:IModifyTicketState,IQueryTicketState
    {
        List<TicketView> Tickets = new List<TicketView>();

        public TicketState()
        {

        }

        public void AddTicket(TenantId Tenant,ProductId Product,TicketId Id,string Name,string Description)
        {
            Tickets.Add(new TicketView {Id = Id,Name = Name,Description = Description});
        }


        public TicketView GetById(TenantId Tenant,ProductId Product,TicketId TicketId)
        {
            return Tickets.FirstOrDefault(x=>x.Id == TicketId);
        }


        public bool IsActive(TenantId tenant, ProductId product, TicketId ticket)
        {
            return Tickets.Any(x => x.Id == ticket); 
        }

        public void TicketRegistered(TenantId Tenant, ProductId Product, TicketId Id, string Name, string Description)
        {
            Tickets.Add(new TicketView {  Id = Id,Name = Name,Description = Description});
        }
    }
}
