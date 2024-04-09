using HelpHub.Application.Models.Collaboration;

namespace HelpHub.Application.Contracts.ServiceInterfaces;

public interface ICollaborationService
{
    Task Delete(string collaborationId);

    Task Add(CollaborationModel collaborationModel);

    Task<CollaborationModel?> FindById(string collaborationId);
}