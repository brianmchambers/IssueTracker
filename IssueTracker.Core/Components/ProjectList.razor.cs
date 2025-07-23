using IssueTracker.Core.Models;
using IssueTracker.Core.Services;
using Microsoft.AspNetCore.Components;

namespace IssueTracker.Core.Components
{
    public partial class ProjectList : ComponentBase
    {
        [Parameter]
        public List<Project> Projects { get; set; } = [];

        [Parameter]
        public EventCallback<Guid> OnProjectSelected { get; set; }
    }
}
