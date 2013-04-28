using SaasOvation.Common.Domain.Model;
using System;

namespace SaasOvation.IssueTrack.Domain.Model.IssueAssigners
{
    public class Id: GenericId
    {
        protected override string TypeString
        {
            get { return "issueassigner"; }
        }

        public Id(object somevalue):base(somevalue)  { }
    }
}
