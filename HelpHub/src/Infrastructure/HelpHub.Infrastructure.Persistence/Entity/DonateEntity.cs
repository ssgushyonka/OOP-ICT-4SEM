namespace HelpHub.Infrastructure.Persistence.Entity;

public class DonateEntity
{
    public string? DonateId { get; set; }

    public string? Coin { get; set; } = null!;

    public DateTime DateTime { get; set; }

    public string? UserId { get; set; }

    public string? EventId { get; set; }
}