using HelpHub.Application.Models.Event;

namespace HelpHub.Application.Contracts.ServiceInterfaces;

public interface IEventService
{
    Task<EventModel?> GetEvent(string eventId);

    Task Delete(EventModel eventId);

    Task<string?> GetEventName(string eventId);

    Task UpdateName(string eventId, string newName);

    Task UpdateLocation(string eventId, string newLocation);
}
