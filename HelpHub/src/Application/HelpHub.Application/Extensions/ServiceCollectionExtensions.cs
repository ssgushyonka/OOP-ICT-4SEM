using HelpHub.Application.Contracts.ServiceInterfaces;
using HelpHub.Application.Service;
using HelpHub.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace HelpHub.Application.Extensions;

using Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection collection)
    {
        // TODO: add services
        collection.AddScoped<IOrganizatorService, OrganizatorService>();
        collection.AddScoped<IUserService, UserService>();
        collection.AddScoped<IEventService, EventService>();
        collection.AddScoped<IDonateService, DonateService>();
        collection.AddScoped<ICollaborationService, CollaborationService>();
        return collection;
    }

    public static IServiceCollection AddInfrastructurePersistence(this IServiceCollection collection, IConfiguration configuration)
    {
        collection.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql(configuration.GetSection("Infrastructure:Persistence:Postgres:ConnectionString").Value));
        return collection;
    }
}