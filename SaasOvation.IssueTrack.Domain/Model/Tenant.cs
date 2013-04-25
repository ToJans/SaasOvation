using System;

namespace SaasOvation.IssueTrack.Domain.Model
{
    public class TenantId : GenericId
    {
        protected override string TypeString { get { return "tenant"; } }

        public TenantId(Guid somevalue) : base(somevalue) { }
    }

}
