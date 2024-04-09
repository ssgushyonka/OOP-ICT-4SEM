namespace HelpHub.Application.Models.Event;

public class EventModel
{
    private string? EventId { get; set; }

    private string? Name { get; set; }

    private string? Location { get; set; }

    private string? OrganizatorId { get; set; }

    private DateTime StartDate { get; set; }

    private DateTime EndDate { get; set; }

    public EventModel(
        string? eventId,
        string? name,
        string? location,
        DateTime startDate,
        DateTime endDate,
        string? organizatorId)
    {
        EventId = eventId;
        Name = name;
        Location = location;
        StartDate = startDate;
        EndDate = endDate;
        OrganizatorId = organizatorId;
    }

    public static EventModelBuilder Builder()
    {
        return new EventModelBuilder();
    }

    public string? GetEventId()
    {
        return EventId;
    }

    public string? GetEventName()
    {
        return Name;
    }

    public string? GetLocation()
    {
        return Location;
    }

    public DateTime GetStartDate()
    {
        return StartDate;
    }

    public DateTime GetEndDate()
    {
        return EndDate;
    }

    public string? GetOrganizatorId()
    {
        return OrganizatorId;
    }
}