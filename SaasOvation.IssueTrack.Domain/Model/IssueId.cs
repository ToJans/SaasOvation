using System;

namespace SaasOvation.IssueTrack.Domain.Model
{
    public class IssueId : GenericId
    {
        public IssueId(Guid id) : base(id) { }

        protected override string TypeString
        {
            get { return "issue"; }
        }
    }
}
