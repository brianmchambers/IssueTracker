namespace IssueTracker.Core.Models;

public sealed record Project
{
    public required Guid Id { get; init; }
    public required string Name { get; init; }
    public string? Description { get; init; }

    public DateTime CreatedAt { get; init; } = DateTime.UtcNow;

    public List<Ticket> Tickets { get; init; } = [];
}