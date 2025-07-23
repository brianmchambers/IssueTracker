namespace IssueTracker.Core.Models;

public sealed class MockDataStore
{
    public List<Project> Projects { get; } = [];
    public List<Ticket> Tickets { get; } = [];

    public MockDataStore()
    {
        var project1 = new Project
        {
            Id = Guid.NewGuid(),
            Name = "Project Apollo",
            Description = "Legacy system migration to cloud infrastructure.",
            CreatedAt = DateTime.UtcNow.AddDays(-30)
        };

        var project2 = new Project
        {
            Id = Guid.NewGuid(),
            Name = "Project Neptune",
            Description = "New analytics dashboard for executive reporting.",
            CreatedAt = DateTime.UtcNow.AddDays(-20)
        };

        var project3 = new Project
        {
            Id = Guid.NewGuid(),
            Name = "Project Helix",
            Description = "Internal tool for automating deployment pipelines.",
            CreatedAt = DateTime.UtcNow.AddDays(-10)
        };

        var project4 = new Project
        {
            Id = Guid.NewGuid(),
            Name = "Project Atlas",
            Description = "Cross-platform mobile app for field service teams.",
            CreatedAt = DateTime.UtcNow.AddDays(-5)
        };

        Projects.AddRange([project1, project2, project3, project4]);

        Tickets.AddRange([
            new Ticket {
                Id = Guid.NewGuid(),
                Title = "Fix login bug",
                ProjectId = project1.Id,
                Status = TicketStatus.Open,
                AssignedTo = "Brian",
                CreatedAt = DateTime.UtcNow.AddDays(-2)
            },
            new Ticket {
                Id = Guid.NewGuid(),
                Title = "Migrate database to Azure SQL",
                ProjectId = project1.Id,
                Status = TicketStatus.InProgress,
                AssignedTo = "Alex",
                CreatedAt = DateTime.UtcNow.AddDays(-1)
            },
            new Ticket {
                Id = Guid.NewGuid(),
                Title = "Generate executive report charts",
                ProjectId = project2.Id,
                Status = TicketStatus.InProgress,
                AssignedTo = "Jade",
                CreatedAt = DateTime.UtcNow.AddDays(-3)
            },
            new Ticket {
                Id = Guid.NewGuid(),
                Title = "Add user filters to dashboard",
                ProjectId = project2.Id,
                Status = TicketStatus.Open,
                AssignedTo = "Brian",
                CreatedAt = DateTime.UtcNow.AddDays(-1)
            },
            new Ticket {
                Id = Guid.NewGuid(),
                Title = "Integrate GitHub Actions CI",
                ProjectId = project3.Id,
                Status = TicketStatus.Resolved,
                AssignedTo = "Sam",
                CreatedAt = DateTime.UtcNow.AddDays(-4)
            },
            new Ticket {
                Id = Guid.NewGuid(),
                Title = "Fix crash on iOS login screen",
                ProjectId = project4.Id,
                Status = TicketStatus.Open,
                AssignedTo = "Brian",
                CreatedAt = DateTime.UtcNow
            }
        ]);
    }
}
