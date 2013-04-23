using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaasOvation.IssueTrack.Domain.Model
{
    public abstract class GenericId
    {
        protected abstract string TypeString { get; }

        private string Value;

        public GenericId(Guid someId)
        {
            this.Value = string.Format("{0}/{1}", TypeString, someId);
        }

        public override bool Equals(object obj)
        {
            return obj is GenericId && Value == ((GenericId)obj).Value;
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }
    }

}
