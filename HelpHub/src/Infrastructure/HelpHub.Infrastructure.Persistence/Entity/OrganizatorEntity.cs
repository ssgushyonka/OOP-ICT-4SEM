namespace HelpHub.Infrastructure.Persistence.Entity;

public class OrganizatorEntity
{
    public string? OrganizatorId { get; set; }

    public string? Name { get; set; } = null!;

    public string? Description { get; set; } = null!;

    public string? Contacts { get; set; } = null!;
}