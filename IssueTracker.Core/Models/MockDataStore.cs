namespace IssueTracker.Core.Models;

public sealed class MockDataStore
{
    public List<Project> Projects { get; } = [];
    public List<Ticket> Tickets { get; } = [];

    public MockDataStore()
    {
        var project1 = new Project { Id = Guid.NewGuid(), Name = "Project Apollo", Description = "..." };
        var project2 = new Project { Id = Guid.NewGuid(), Name = "Project Neptune", Description = "..." };

        Projects.AddRange([project1, project2]);

        Tickets.AddRange([
            new Ticket {
                Id = Guid.NewGuid(),
                Title = "Fix login bug",
                ProjectId = project1.Id,
                Status = TicketStatus.Open,
                AssignedTo = "Brian",
                CreatedAt = DateTime.UtcNow
            },
            new Ticket {
                Id = Guid.NewGuid(),
                Title = "Generate report",
                ProjectId = project2.Id,
                Status = TicketStatus.InProgress
            }
        ]);
    }
}