using HelpHub.Application.Abstractions.Persistence.Repositories;
using HelpHub.Application.Models.Event;
using HelpHub.Infrastructure.Persistence.Contexts;
using HelpHub.Infrastructure.Persistence.Entity;
using HelpHub.Infrastructure.Persistence.Utils;

namespace HelpHub.Infrastructure.Persistence.Repositories;

using Microsoft.EntityFrameworkCore;

public class EventRepository(ApplicationDbContext context) : IEventRepository
{
    private const int IdLength = 10;

    public async Task<EventModel?> FindEventById(string eventId)
    {
        var eventEntity = await context.Events.FirstOrDefaultAsync(c => c.EventId == eventId);
        return eventEntity != null ? MapEntityToModel(eventEntity) : null;
    }

    public async Task SaveNewEvent(EventModel eventModel)
    {
        var newEventEntity = new EventEntity
        {
            EventId = Generator.GenerateRandomId(IdLength),
            Name = eventModel.GetEventName(),
        };

        context.Events.Add(newEventEntity);
        await context.SaveChangesAsync();
    }

    public async Task<List<EventModel>> FindAllEventsByOrganizatorId(string organizatorId)
    {
        List<EventModel> courses = await context.Events.Select(
                t => new EventModel(t.EventId, t.Name, t.Location, t.StartDate, t.EndDate, t.OrganizatorId))
             .ToListAsync();
        return courses;
    }

    public async Task UpdateEvent(EventModel eventModel)
    {
        var eventEntityToUpdate = MapModelToEntity(eventModel);
        context.Entry(eventEntityToUpdate).State = EntityState.Modified;
        await context.SaveChangesAsync();
    }

    public async Task DeleteEvent(EventModel eventModel)
    {
        var eventEntityToDelete = MapModelToEntity(eventModel);
        context.Events.Remove(await eventEntityToDelete);
        await context.SaveChangesAsync();
    }

    private EventModel MapEntityToModel(EventEntity eventEntity)
    {
        return EventModel.Builder()
            .EventId(eventEntity.EventId)
            .Name(eventEntity.Name)
            .StartDate(eventEntity.StartDate)
            .EndDate(eventEntity.EndDate)
            .Build();
    }

    private Task<EventEntity> MapModelToEntity(EventModel eventModel)
    {
        return Task.FromResult(new EventEntity
        {
            EventId = eventModel.GetEventId(),
            Name = eventModel.GetEventName(),
            OrganizatorId = eventModel.GetOrganizatorId(),
        });
    }
}