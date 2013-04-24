using SaasOvation.IssueTrack.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SaasOvation.IssueTrack.Domain
{
    public class TicketView
    {
        public string Name;
        public TicketId Id;

        public string Description { get; set; }
    }
}
