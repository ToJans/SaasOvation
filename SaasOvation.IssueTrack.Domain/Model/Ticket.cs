using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaasOvation.IssueTrack.Domain.Model
{
    public class TicketId: GenericId
    {
        public TicketId(Guid id):base(id) { }

        protected override string TypeString
        {
            get { return "ticket"; }
        }
    }

    public class Ticket
    {
        public TenantId Tenant { get; set; }
        public ProductId Product { get; set; }
        public TicketId Id { get; set; }
    }
}
