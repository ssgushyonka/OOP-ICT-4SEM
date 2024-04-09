using HelpHub.Application.Models.Collaboration;

namespace HelpHub.Application.Abstractions.Persistence.Repositories;

public interface ICollaborationRepository
{
    Task Add(CollaborationModel collaborationModel);

    Task Delete(CollaborationModel collaborationModel);

    Task<CollaborationModel?> FindCollaborationById(string collaborationId);
}