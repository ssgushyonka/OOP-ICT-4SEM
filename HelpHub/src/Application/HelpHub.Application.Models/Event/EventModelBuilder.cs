namespace HelpHub.Application.Models.Event;

public class EventModelBuilder
{
    private string? _eventId;
    private string? _name;
    private string? _location;
    private string? _organizatorId;
    private DateTime _startDate;
    private DateTime _endDate;

    public EventModelBuilder EventId(string? eventId)
    {
        _eventId = eventId;
        return this;
    }

    public EventModelBuilder Name(string? name)
    {
        _name = name;
        return this;
    }

    public EventModelBuilder Location(string? location)
    {
        _location = location;
        return this;
    }

    public EventModelBuilder StartDate(DateTime startDate)
    {
        _startDate = startDate;
        return this;
    }

    public EventModelBuilder EndDate(DateTime endDate)
    {
        _endDate = endDate;
        return this;
    }

    public EventModelBuilder OrganizatorId(string? organizatorId)
    {
        _organizatorId = organizatorId;
        return this;
    }

    public EventModel Build()
    {
        return new EventModel(_eventId, _name, _location, _startDate, _endDate, _organizatorId);
    }
}