using HelpHub.Application.Models.Event;
namespace HelpHub.Application.Abstractions.Persistence.Repositories;

public interface IEventRepository
{
    Task<List<EventModel>> FindAllEventsByOrganizatorId(string organizatorId);

    Task<EventModel?> FindEventById(string eventId);

    Task SaveNewEvent(EventModel eventModel);

    Task UpdateEvent(EventModel eventModel);

    Task DeleteEvent(EventModel eventModel);
}