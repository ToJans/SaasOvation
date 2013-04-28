using System;

namespace SaasOvation.Common.Domain.Model
{
    public static class Guard
    {
        public static void That(bool assertion, string description)
        {
            if (!assertion) throw new InvalidOperationException(description);
        }

        public static void Against(bool assertion, string description)
        {
            if (assertion) throw new InvalidOperationException(description);
        }
    }
}
