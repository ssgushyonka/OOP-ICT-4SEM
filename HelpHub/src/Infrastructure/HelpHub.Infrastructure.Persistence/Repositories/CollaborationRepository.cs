using HelpHub.Application.Models.Collaboration;

namespace HelpHub.Infrastructure.Persistence.Repositories;

using HelpHub.Application.Abstractions.Persistence.Repositories;
using HelpHub.Infrastructure.Persistence.Contexts;
using HelpHub.Infrastructure.Persistence.Entity;
using HelpHub.Infrastructure.Persistence.Utils;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

public class CollaborationRepository(ApplicationDbContext context) : ICollaborationRepository
{
    private const int IdLength = 10;

    public async Task<CollaborationModel?> FindCollaborationById(string collaborationId)
    {
        var collaborationEntity = await context.Collaboration.FirstOrDefaultAsync(u => u.CollaborationId == collaborationId);
        return collaborationEntity != null ? MapEntityToModel(collaborationEntity) : null;
    }

    public async Task Add(CollaborationModel collaborationModel)
    {
        var newCollaborationEntity = new CollaborationEntity
        {
            CollaborationId = Generator.GenerateRandomId(IdLength),
            UserId = collaborationModel.GetUserId(),
            EventId = collaborationModel.GetEventId(),
        };

        context.Collaboration.Add(newCollaborationEntity);
        await context.SaveChangesAsync();
    }

    public async Task Delete(CollaborationModel collaborationModel)
    {
        var collaborationEntityToDelete = MapModelToEntity(collaborationModel);
        context.Collaboration.Remove(await collaborationEntityToDelete);
        await context.SaveChangesAsync();
    }

    private CollaborationModel MapEntityToModel(CollaborationEntity collaboration)
    {
        return CollaborationModel.Builder()
            .CollaborationId(collaboration.CollaborationId)
            .UserId(collaboration.UserId)
            .EventId(collaboration.EventId)
            .Build();
    }

    private Task<CollaborationEntity> MapModelToEntity(CollaborationModel collaborationModel)
    {
        return Task.FromResult(new CollaborationEntity
        {
            CollaborationId = collaborationModel.GetCollaborationId(),
            EventId = collaborationModel.GetEventId(),
            UserId = collaborationModel.GetUserId(),
        });
    }
}
