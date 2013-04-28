using SaasOvation.IssueTrack.Domain.Model;

namespace SaasOvation.IssueTrack.Domain.Model.Issues
{
    public class View
    {
        public string Name;
        public Id Id;

        public string Description { get; set; }

        public IssueAssigners.Id Assigner { get; set; }
    }
}
