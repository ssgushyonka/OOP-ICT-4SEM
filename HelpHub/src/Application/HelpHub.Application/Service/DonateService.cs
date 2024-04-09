using HelpHub.Application.Contracts.ServiceInterfaces;
using HelpHub.Application.Models.Donate;
using HelpHub.Infrastructure.Persistence.Repositories;
using System.Collections.ObjectModel;

namespace HelpHub.Application.Service;

public class DonateService : IDonateService
{
    private readonly DonateRepository _donateRepository;

    public DonateService(DonateRepository donateRepository, CollaborationRepository collaborationRepository)
    {
        _donateRepository = donateRepository;
    }

    public async Task Create(DonateModel model)
    {
        await _donateRepository.SaveNewDonate(model);
    }

    public Collection<DonateModel> FindAll()
    {
        return new Collection<DonateModel>(_donateRepository.FindAllDonates().Result);
    }
}