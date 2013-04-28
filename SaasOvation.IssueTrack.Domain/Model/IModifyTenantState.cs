using System;
namespace SaasOvation.IssueTrack.Domain.Model
{
    interface IModifyTenantState
    {
        void TenantActivated(TenantId a_tenant_id);
    }
}
