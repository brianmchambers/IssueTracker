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

    [Parameter]
    public EventCallback<Ticket> OnTicketDeleted { get; set; }

    protected List<Ticket> Tickets { get; set; } = [];

    private Guid? SelectedTicketId;

    private void HandleTicketUpdated(Ticket updated)
    {
        var index = Tickets.FindIndex(t => t.Id == updated.Id);
        if (index >= 0)
        {
            Tickets[index] = updated;
        }

        SelectedTicketId = updated.Id;
        StateHasChanged();
    }

    private void HandleTicketDeleted(Ticket deleted)
    {
        Tickets.RemoveAll(t => t.Id == deleted.Id);
        SelectedTicketId = null;
        StateHasChanged();
    }

    protected override async Task OnParametersSetAsync()
    {
        SelectedTicketId = null;

        if (ProjectId != Guid.Empty)
        {
            Tickets = await TicketService.GetByProjectIdAsync(ProjectId);
        }
    }

    private void HandleTicketSelected(Guid ticketId)
    {
        SelectedTicketId = ticketId;
    }
}