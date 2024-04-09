using HelpHub.Application.Contracts.ServiceInterfaces;
using HelpHub.Application.Models.Event;

using HelpHub.Infrastructure.Persistence.Repositories;

namespace HelpHub.Application.Service;

public class EventService : IEventService
{
    private readonly EventRepository _eventRepository;

    public EventService(EventRepository eventRepository, OrganizatorRepository organizatorRepository)
    {
        _eventRepository = eventRepository;
    }

    public Task<EventModel?> GetEvent(string eventId)
    {
        return Task.FromResult(_eventRepository.FindEventById(eventId).Result);
    }

    public async Task Delete(EventModel eventId)
    {
        await _eventRepository.DeleteEvent(eventId);
    }

    public Task<string?> GetEventName(string eventId)
    {
        return Task.FromResult(_eventRepository.FindEventById(eventId).Result?.GetEventId());
    }

    public async Task UpdateName(string eventId, string? newName)
    {
        var eventModel = _eventRepository.FindEventById(eventId).Result;
        if (eventModel != null)
        {
            var newEvent = EventModel.Builder()
                .EventId(eventId)
                .Name(newName)
                .Location(eventModel.GetLocation())
                .StartDate(eventModel.GetStartDate())
                .EndDate(eventModel.GetEndDate())
                .Build();
            await _eventRepository.UpdateEvent(newEvent);
        }
    }

    public async Task UpdateLocation(string eventId, string newLocation)
    {
        var eventModel = _eventRepository.FindEventById(eventId).Result;
        if (eventModel != null)
        {
            var newEvent = EventModel.Builder()
                .EventId(eventId)
                .Name(eventModel.GetEventName())
                .Location(eventModel.GetLocation())
                .StartDate(eventModel.GetStartDate())
                .EndDate(eventModel.GetEndDate())
                .Build();
            await _eventRepository.UpdateEvent(newEvent);
        }
    }
}