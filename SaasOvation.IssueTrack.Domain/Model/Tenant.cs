using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaasOvation.IssueTrack.Domain.Model
{
    public class TenantId : GenericId
    {
        protected override string TypeString { get { return "tenant"; } }

        public TenantId(Guid somevalue) : base(somevalue) { }
    }

}
