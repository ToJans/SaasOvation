using System;

namespace SaasOvation.Common.Domain.Model
{
    public abstract class GenericId
    {
        protected abstract string TypeString { get; }

        private string Value;

        public GenericId(object someId)
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
