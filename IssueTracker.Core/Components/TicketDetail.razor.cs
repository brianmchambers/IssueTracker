using IssueTracker.Core.Models;
using IssueTracker.Core.Services;
using Microsoft.AspNetCore.Components;

namespace IssueTracker.Core.Components;

public partial class TicketDetail : ComponentBase
{
    [Inject]
    public TicketService TicketService { get; set; } = default!;

    [Parameter]
    public Guid TicketId { get; set; }

    protected Ticket? Ticket { get; set; }

    protected override async Task OnParametersSetAsync()
    {
        if (TicketId != Guid.Empty)
        {
            Ticket = await TicketService.GetByIdAsync(TicketId);
        }
    }
}