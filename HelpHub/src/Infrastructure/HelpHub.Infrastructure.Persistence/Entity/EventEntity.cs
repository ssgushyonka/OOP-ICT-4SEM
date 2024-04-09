namespace HelpHub.Infrastructure.Persistence.Entity;

public class EventEntity
{
    public string? EventId { get; set; }

    public string? Name { get; set; } = null!;

    public string? Location { get; set; } = null!;

    public string? OrganizatorId { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }
}