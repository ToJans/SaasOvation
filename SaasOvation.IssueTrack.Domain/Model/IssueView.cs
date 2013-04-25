using SaasOvation.IssueTrack.Domain.Model;

namespace SaasOvation.IssueTrack.Domain
{
    public class IssueView
    {
        public string Name;
        public IssueId Id;

        public string Description { get; set; }

        public IssueAssignerId Assigner { get; set; }
    }
}
