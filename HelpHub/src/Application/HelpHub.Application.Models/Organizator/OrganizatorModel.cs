namespace HelpHub.Application.Models.Organizator;

public class OrganizatorModel
{
    public string? OrganizatorId { get; set; }

    private string? Name { get; set; }

    private string? Description { get; set; }

    private string? Contacts { get; set; }

    public OrganizatorModel(
        string? organizatorId,
        string? name,
        string? description,
        string? contacts)
    {
        OrganizatorId = organizatorId;
        Name = name;
        Description = description;
        Contacts = contacts;
    }

    public static OrganizatorModelBuilder Builder()
    {
        return new OrganizatorModelBuilder();
    }

    public string? GetName()
    {
        return Name;
    }

    public string? GetDescription()
    {
        return Description;
    }

    public string? GetContacts()
    {
        return Contacts;
    }
}