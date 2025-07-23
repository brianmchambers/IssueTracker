using IssueTracker.Core.Models;

namespace IssueTracker.Core.Services;

public class TicketService(MockDataStore store)
{
    public Task<List<Ticket>> GetAllAsync()
    {
        return Task.FromResult(store.Tickets);
    }

    public Task<List<Ticket>> GetByProjectIdAsync(Guid projectId)
    {
        return Task.FromResult(store.Tickets.Where(t => t.ProjectId == projectId).ToList());
    }

    public Task<Ticket?> GetByIdAsync(Guid id)
    {
        var ticket = store.Tickets.FirstOrDefault(t => t.Id == id);
        return Task.FromResult(ticket);
    }

    public Task CreateAsync(Ticket ticket)
    {
        ticket = ticket with { Id = Guid.NewGuid(), CreatedAt = DateTime.UtcNow };
        store.Tickets.Add(ticket);
        return Task.CompletedTask;
    }

    public Task UpdateAsync(Ticket ticket)
    {
        var existingTicket = store.Tickets.FirstOrDefault(t => t.Id == ticket.Id);
        if (existingTicket != null)
        {
            store.Tickets.Remove(existingTicket);
            store.Tickets.Add(ticket);
        }
        return Task.CompletedTask;
    }

    public Task DeleteAsync(Guid id)
    {
        var ticket = store.Tickets.FirstOrDefault(t => t.Id == id);
        if (ticket != null)
        {
            store.Tickets.Remove(ticket);
        }
        return Task.CompletedTask;
    }

    public Task<List<Ticket>> GetByStatusAsync(TicketStatus status) 
    { 
        return Task.FromResult(store.Tickets.Where(t => t.Status == status).ToList());
    }

    public Task<List<Ticket>> GetByAssigneeAsync(string assignee)
    {
        return Task.FromResult(store.Tickets.Where(t => t.AssignedTo == assignee).ToList());
    }

    public Task<List<Ticket>> SearchAsync(string keyword)
    {
        return Task.FromResult(store.Tickets
            .Where(t => t.Title.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                        (t.Description?.Contains(keyword, StringComparison.OrdinalIgnoreCase) ?? false))
            .ToList());
    }
}
