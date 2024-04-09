using HelpHub.Application.Contracts.ServiceInterfaces;
using HelpHub.Application.Models.Organizator;
using HelpHub.Infrastructure.Persistence.Repositories;

namespace HelpHub.Application.Service;

public class OrganizatorService : IOrganizatorService
{
    private readonly OrganizatorRepository _organizatorRepository;

    public OrganizatorService(OrganizatorRepository organizatorRepository)
    {
        _organizatorRepository = organizatorRepository;
    }

    public async Task Create(OrganizatorModel organizatorModel)
    {
        await _organizatorRepository.CreateOrganizator(organizatorModel);
    }

    public Task<OrganizatorModel?> FindById(string organizatorId)
    {
        return Task.FromResult(_organizatorRepository.FindOrganizatorById(organizatorId).Result);
    }

    public async Task Delete(string organizatorId)
    {
        var userModel = _organizatorRepository.FindOrganizatorById(organizatorId);
        await _organizatorRepository.DeleteOrganizator(await userModel ?? throw new InvalidOperationException());
    }

    public string? GetOrganizatorName(string userId)
    {
        return _organizatorRepository.FindOrganizatorById(userId).Result?.GetName();
    }

    public string? GetOrganizatorDiscription(string organizatorId)
    {
        return _organizatorRepository.FindOrganizatorById(organizatorId).Result?.GetDescription();
    }

    public string? GetOrganizatorContact(string organizatorId)
    {
        return _organizatorRepository.FindOrganizatorById(organizatorId).Result?.GetContacts();
    }

    public async Task UpdateName(string organizatorId, string newName)
    {
        var organizatorModel = _organizatorRepository.FindOrganizatorById(organizatorId).Result;
        if (organizatorModel != null)
        {
            var newOrganizatorModel = OrganizatorModel.Builder()
                .OrganizatorId(organizatorModel.OrganizatorId)
                .Name(newName)
                .Description(organizatorModel.GetDescription())
                .Contacts(organizatorModel.GetContacts())
                .Build();
            await _organizatorRepository.UpdateOrganizator(newOrganizatorModel);
        }
    }

    public async Task UpdateDiscription(string organizatorId, string newDis)
    {
        var organizatorModel = _organizatorRepository.FindOrganizatorById(organizatorId).Result;
        if (organizatorModel != null)
        {
            var newOrganizatorModel = OrganizatorModel.Builder()
                .OrganizatorId(organizatorModel.OrganizatorId)
                .Name(organizatorModel.GetName())
                .Description(newDis)
                .Contacts(organizatorModel.GetContacts())
                .Build();
            await _organizatorRepository.UpdateOrganizator(newOrganizatorModel);
        }
    }

    public async Task UpdateContact(string organizatorId, string newContact)
    {
        var organizatorModel = _organizatorRepository.FindOrganizatorById(organizatorId).Result;
        if (organizatorModel != null)
        {
            var newOrganizatorModel = OrganizatorModel.Builder()
                .OrganizatorId(organizatorModel.OrganizatorId)
                .Name(organizatorModel.GetName())
                .Description(organizatorModel.GetDescription())
                .Contacts(newContact)
                .Build();
            await _organizatorRepository.UpdateOrganizator(newOrganizatorModel);
        }
    }
}