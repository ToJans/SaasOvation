using SaasOvation.Common.Domain.Model;
using System;

namespace SaasOvation.IssueTrack.Domain.Model.Products
{
    public class Id : GenericId
    {
        protected override string TypeString { get { return "product"; } }

        public Id(object somevalue) : base(somevalue) { }
    }

}
