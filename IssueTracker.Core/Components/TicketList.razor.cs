using IssueTracker.Core.Models;
using IssueTracker.Core.Services;
using Microsoft.AspNetCore.Components;

namespace IssueTracker.Core.Components;

public partial class TicketList : ComponentBase
{
    [Inject]
    public TicketService TicketService { get; set; } = default!;

    [Parameter]
    public Guid ProjectId { get; set; }

    [Parameter]
    public EventCallback<Ticket> OnTicketSelected { get; set; }

    protected List<Ticket> Tickets { get; set; } = [];

    protected override async Task OnParametersSetAsync()
    {
        if (ProjectId != Guid.Empty)
        {
            Tickets = await TicketService.GetByProjectIdAsync(ProjectId);
        }
    }
}