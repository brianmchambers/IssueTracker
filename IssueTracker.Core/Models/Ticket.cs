namespace IssueTracker.Core.Models;

public sealed record Ticket
{
    public required Guid Id { get; init; }
    public required string Title { get; init; }
    public string? Description { get; init; }

    public required TicketStatus Status { get; init; } = TicketStatus.Open;
    public required Guid ProjectId { get; init; }

    public string? AssignedTo { get; init; }
    public DateTime CreatedAt { get; init; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; init; }
}

public enum TicketStatus
{
    Open,
    InProgress,
    Resolved,
    Closed,
    Archived
}