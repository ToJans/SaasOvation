using System;

namespace SaasOvation.IssueTrack.Domain.Model
{
    public class IssueAssignerId: GenericId
    {
        protected override string TypeString
        {
            get { return "issueassigner"; }
        }

        public IssueAssignerId(Guid guid):base(guid)  { }
    }
}
