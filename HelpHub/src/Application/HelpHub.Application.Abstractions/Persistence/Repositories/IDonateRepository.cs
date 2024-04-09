using HelpHub.Application.Models.Donate;

namespace HelpHub.Application.Abstractions.Persistence.Repositories;

public interface IDonateRepository
{
    Task<List<DonateModel>> FindAllDonates();

    Task<DonateModel?> FindDonateId(string donateId);

    Task SaveNewDonate(DonateModel donateModel);
}