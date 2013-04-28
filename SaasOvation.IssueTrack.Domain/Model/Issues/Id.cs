using SaasOvation.Common.Domain.Model;
using System;

namespace SaasOvation.IssueTrack.Domain.Model.Issues
{
    public class Id : GenericId
    {
        public Id(object somevalue) : base(somevalue) { }

        protected override string TypeString
        {
            get { return "issue"; }
        }
    }
}
