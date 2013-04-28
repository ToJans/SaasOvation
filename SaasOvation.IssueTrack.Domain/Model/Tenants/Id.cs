using SaasOvation.Common.Domain.Model;
using System;

namespace SaasOvation.IssueTrack.Domain.Model.Tenants
{
    public class Id : GenericId
    {
        protected override string TypeString { get { return "tenant"; } }

        public Id(object somevalue) : base(somevalue) { }
    }

}
