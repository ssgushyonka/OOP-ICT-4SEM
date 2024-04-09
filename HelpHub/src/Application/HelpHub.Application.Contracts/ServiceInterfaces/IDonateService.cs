using HelpHub.Application.Models.Donate;
using System.Collections.ObjectModel;

namespace HelpHub.Application.Contracts.ServiceInterfaces;

public interface IDonateService
{
    Task Create(DonateModel model);

    Collection<DonateModel> FindAll();
}
