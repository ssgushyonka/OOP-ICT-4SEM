using HelpHub.Application.Contracts.ServiceInterfaces;
using HelpHub.Application.Models.Collaboration;
using HelpHub.Infrastructure.Persistence.Repositories;

namespace HelpHub.Application.Service;

public class CollaborationService : ICollaborationService
{
    private readonly CollaborationRepository _collaborationRepository;

    public CollaborationService(CollaborationRepository collaborationRepository)
    {
        _collaborationRepository = collaborationRepository;
    }

    public async Task Add(CollaborationModel collaborationModel)
    {
        await _collaborationRepository.Add(collaborationModel);
    }

    public Task<CollaborationModel?> FindById(string collaborationId)
    {
        return Task.FromResult(_collaborationRepository.FindCollaborationById(collaborationId).Result);
    }

    public async Task Delete(string collaborationId)
    {
        var collaborationModel = _collaborationRepository.FindCollaborationById(collaborationId);
        await _collaborationRepository.Delete(await collaborationModel ?? throw new InvalidOperationException());
    }
}