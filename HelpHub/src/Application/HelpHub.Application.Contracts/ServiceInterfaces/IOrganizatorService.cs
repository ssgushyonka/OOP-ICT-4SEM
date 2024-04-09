using HelpHub.Application.Models.Organizator;

namespace HelpHub.Application.Contracts.ServiceInterfaces;

public interface IOrganizatorService
{
    Task Create(OrganizatorModel organizatorModel);

    Task UpdateName(string organizatorId, string newName);

    Task UpdateDiscription(string organizatorId, string newDis);

    Task UpdateContact(string organizatorId, string newContact);

    Task Delete(string organizatorId);

    Task<OrganizatorModel?> FindById(string organizatorId);
}