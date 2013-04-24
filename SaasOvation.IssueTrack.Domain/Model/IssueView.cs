using SaasOvation.IssueTrack.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SaasOvation.IssueTrack.Domain
{
    public class IssueView
    {
        public string Name;
        public IssueId Id;

        public string Description { get; set; }

        public IssueAssignerId Assigner { get; set; }
    }
}
