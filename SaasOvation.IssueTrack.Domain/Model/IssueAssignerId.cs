using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
