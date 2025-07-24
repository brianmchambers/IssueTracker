namespace IssueTracker.Core.Models;

public sealed record Ticket
{
    public required Guid Id { get; set; }
    public required string Title { get; set; }
    public string? Description { get; set; }

    public required TicketStatus Status { get; set; } = TicketStatus.Open;
    public required Guid ProjectId { get; set; }

    public string? AssignedTo { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
}

public enum TicketStatus
{
    Open,
    InProgress,
    Resolved,
    Closed,
    Archived
}