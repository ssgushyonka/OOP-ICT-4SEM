using HelpHub.Application.Abstractions.Persistence.Repositories;
using HelpHub.Application.Models.Organizator;
using HelpHub.Infrastructure.Persistence.Contexts;
using HelpHub.Infrastructure.Persistence.Entity;
using HelpHub.Infrastructure.Persistence.Utils;

namespace HelpHub.Infrastructure.Persistence.Repositories;

using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

public class OrganizatorRepository(ApplicationDbContext context) : IOrganizatorRepository
{
    private const int IdLength = 10;

    public async Task<OrganizatorModel?> FindOrganizatorById(string organizatorId)
    {
        var organizatorEntity = await context.Organizator.FirstOrDefaultAsync(u => u.OrganizatorId == organizatorId);
        return organizatorEntity != null ? MapEntityToModel(organizatorEntity) : null;
    }

    public async Task CreateOrganizator(OrganizatorModel organizatorModel)
    {
        var newOrganizatorEntity = new OrganizatorEntity
        {
            OrganizatorId = Generator.GenerateRandomId(IdLength),
            Name = organizatorModel.GetName(),
            Description = organizatorModel.GetDescription(),
            Contacts = organizatorModel.GetContacts(),
        };

        context.Organizator.Add(newOrganizatorEntity);
        await context.SaveChangesAsync();
    }

    public async Task UpdateOrganizator(OrganizatorModel organizatorModel)
    {
        var organizatorEntityToUpdate = MapModelToEntity(organizatorModel);
        context.Entry(organizatorEntityToUpdate).State = EntityState.Modified;
        await context.SaveChangesAsync();
    }

    public async Task DeleteOrganizator(OrganizatorModel organizatorModel)
    {
        var organizatorEntityToDelete = MapModelToEntity(organizatorModel);
        context.Organizator.Remove(await organizatorEntityToDelete);
        await context.SaveChangesAsync();
    }

    private OrganizatorModel MapEntityToModel(OrganizatorEntity organizator)
    {
        return OrganizatorModel.Builder()
            .OrganizatorId(organizator.OrganizatorId)
            .Name(organizator.Name)
            .Description(organizator.Description)
            .Contacts(organizator.Contacts)
            .Build();
    }

    private Task<OrganizatorEntity> MapModelToEntity(OrganizatorModel organizatorModel)
    {
        return Task.FromResult(new OrganizatorEntity
        {
            Name = organizatorModel.GetName(),
            Description = organizatorModel.GetDescription(),
            Contacts = organizatorModel.GetContacts(),
            OrganizatorId = organizatorModel.OrganizatorId,
        });
    }
}
