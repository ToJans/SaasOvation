using System;

namespace SaasOvation.IssueTrack.Domain.Model
{
    public class ProductId : GenericId
    {
        protected override string TypeString { get { return "product"; } }

        public ProductId(Guid somevalue) : base(somevalue) { }
    }

}
