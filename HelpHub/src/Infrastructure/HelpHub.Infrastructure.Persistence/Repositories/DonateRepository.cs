using HelpHub.Application.Abstractions.Persistence.Repositories;
using HelpHub.Application.Models.Donate;
using HelpHub.Infrastructure.Persistence.Contexts;
using HelpHub.Infrastructure.Persistence.Entity;
using HelpHub.Infrastructure.Persistence.Utils;

namespace HelpHub.Infrastructure.Persistence.Repositories;

using Microsoft.EntityFrameworkCore;

public class DonateRepository(ApplicationDbContext context) : IDonateRepository
{
    private const int IdLength = 10;

    public async Task<DonateModel?> FindDonateId(string donateId)
    {
        var donateEntity = await context.Donatess.FirstOrDefaultAsync(c => c.DonateId == donateId);
        return donateEntity != null ? MapEntityToModel(donateEntity) : null;
    }

    public async Task SaveNewDonate(DonateModel donateModel)
    {
        var newDonateEntity = new DonateEntity
        {
            EventId = Generator.GenerateRandomId(IdLength),
            Coin = donateModel.GetCoin(),
        };

        context.Donatess.Add(newDonateEntity);
        await context.SaveChangesAsync();
    }

    public async Task<List<DonateModel>> FindAllDonates()
    {
        List<DonateModel> donates = await context.Donatess.Select(
                t => new DonateModel(t.DonateId, t.Coin, t.UserId, t.EventId, t.DateTime))
            .ToListAsync();
        return donates;
    }

    private DonateModel MapEntityToModel(DonateEntity donateEntity)
    {
        return DonateModel.Builder()
            .DonateId(donateEntity.DonateId)
            .Coin(donateEntity.Coin)
            .EventId(donateEntity.EventId)
            .DateTime(donateEntity.DateTime)
            .UserId(donateEntity.UserId)
            .Build();
    }
}