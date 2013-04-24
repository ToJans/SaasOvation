using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaasOvation.IssueTrack.Domain.Model
{
    public class IssueId: GenericId
    {
        public IssueId(Guid id):base(id) { }

        protected override string TypeString
        {
            get { return "issue"; }
        }
    }

    public class Issue
    {
        public TenantId Tenant { get; set; }
        public ProductId Product { get; set; }
        public IssueId Id { get; set; }
    }
}
