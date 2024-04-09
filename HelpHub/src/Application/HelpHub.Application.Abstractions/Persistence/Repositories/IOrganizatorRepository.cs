using HelpHub.Application.Models.Organizator;

namespace HelpHub.Application.Abstractions.Persistence.Repositories;

public interface IOrganizatorRepository
{
    Task<OrganizatorModel?> FindOrganizatorById(string organizatorId);

    Task CreateOrganizator(OrganizatorModel organizatorModel);

    Task UpdateOrganizator(OrganizatorModel organizatorModel);

    Task DeleteOrganizator(OrganizatorModel organizatorModel);
}
