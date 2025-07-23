using IssueTracker.Core.Models;

namespace IssueTracker.Core.Services;

public class TicketService
{
    private readonly List<Project> _projects = [];
    private readonly List<Ticket> _tickets = [];

    public TicketService()
    {
        var projectA = new Project
        {
            Id = Guid.NewGuid(),
            Name = "Project Apollo",
            Description = "Authentication & user access control"
        };

        var projectB = new Project
        {
            Id = Guid.NewGuid(),
            Name = "Project Neptune",
            Description = "Reporting engine overhaul"
        };

        _projects.AddRange([projectA, projectB]);

        _tickets.AddRange([
            new Ticket
        {
            Id = Guid.NewGuid(),
            Title = "Fix login redirect",
            Description = "Users are redirected incorrectly after login.",
            Status = TicketStatus.Open,
            ProjectId = projectA.Id,
            AssignedTo = "Brian",
            CreatedAt = DateTime.UtcNow.AddDays(-3)
        },
        new Ticket
        {
            Id = Guid.NewGuid(),
            Title = "Generate quarterly reports",
            Status = TicketStatus.InProgress,
            ProjectId = projectB.Id,
            AssignedTo = "Samantha"
        }
        ]);
    }

    Task<List<Ticket>> GetAllAsync()
    {
        return Task.FromResult(_tickets);
    }

    Task<List<Ticket>> GetByProjectIdAsync(Guid projectId)
    {
        return Task.FromResult(_tickets.Where(t => t.ProjectId == projectId).ToList());
    }

    Task<Ticket?> GetByIdAsync(Guid id)
    {
        var ticket = _tickets.FirstOrDefault(t => t.Id == id);
        return Task.FromResult(ticket);
    }

    Task CreateAsync(Ticket ticket)
    {
        ticket = ticket with { Id = Guid.NewGuid(), CreatedAt = DateTime.UtcNow };
        _tickets.Add(ticket);
        return Task.CompletedTask;
    }

    Task UpdateAsync(Ticket ticket)
    {
        var existingTicket = _tickets.FirstOrDefault(t => t.Id == ticket.Id);
        if (existingTicket != null)
        {
            _tickets.Remove(existingTicket);
            _tickets.Add(ticket);
        }
        return Task.CompletedTask;
    }

    Task DeleteAsync(Guid id)
    {
        var ticket = _tickets.FirstOrDefault(t => t.Id == id);
        if (ticket != null)
        {
            _tickets.Remove(ticket);
        }
        return Task.CompletedTask;
    }

    Task<List<Ticket>> GetByStatusAsync(TicketStatus status) 
    { 
        return Task.FromResult(_tickets.Where(t => t.Status == status).ToList());
    }

    Task<List<Ticket>> GetByAssigneeAsync(string assignee)
    {
        return Task.FromResult(_tickets.Where(t => t.AssignedTo == assignee).ToList());
    }

    Task<List<Ticket>> SearchAsync(string keyword)
    {
        return Task.FromResult(_tickets
            .Where(t => t.Title.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                        (t.Description?.Contains(keyword, StringComparison.OrdinalIgnoreCase) ?? false))
            .ToList());
    }
}
