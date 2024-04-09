namespace HelpHub.Application.Models.Organizator;

public class OrganizatorModelBuilder
{
    private string? _organizatorId;
    private string? _name;
    private string? _description;
    private string? _contacts;

    public OrganizatorModelBuilder OrganizatorId(string? organizatorId)
    {
        _organizatorId = organizatorId;
        return this;
    }

    public OrganizatorModelBuilder Name(string? name)
    {
        _name = name;
        return this;
    }

    public OrganizatorModelBuilder Description(string? description)
    {
        _description = description;
        return this;
    }

    public OrganizatorModelBuilder Contacts(string? contacts)
    {
        _contacts = contacts;
        return this;
    }

    public OrganizatorModel Build()
    {
        return new OrganizatorModel(_organizatorId, _name, _description, _contacts);
    }
}