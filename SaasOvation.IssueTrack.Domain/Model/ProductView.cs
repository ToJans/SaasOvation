using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SaasOvation.IssueTrack.Domain.Model
{
    public class ProductView
    {
        public ProductId Id { get; set; }
        public TenantId TenantId { get; set; }
    }
}
