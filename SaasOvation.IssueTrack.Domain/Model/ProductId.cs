using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaasOvation.IssueTrack.Domain.Model
{
    public class ProductId : GenericId
    {
        protected override string TypeString { get { return "product"; } }

        public ProductId(Guid somevalue) : base(somevalue) { }
    }

}
