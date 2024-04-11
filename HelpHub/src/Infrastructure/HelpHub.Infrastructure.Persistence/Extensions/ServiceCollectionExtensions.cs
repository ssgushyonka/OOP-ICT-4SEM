using HelpHub.Application.Abstractions.Persistence.Repositories;
using HelpHub.Infrastructure.Persistence.Repositories;
using Microsoft.Extensions.Configuration;

namespace HelpHub.Infrastructure.Persistence.Extensions;

using HelpHub.Infrastructure.Persistence.Migrations;
using HelpHub.Infrastructure.Persistence.Plugins;
using Itmo.Dev.Platform.Postgres.Extensions;
using Itmo.Dev.Platform.Postgres.Plugins;
using Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructurePersistence(
        this IServiceCollection collection,
        ConfigurationManager builderConfiguration)
    {
        collection.AddPlatformPostgres(builder => builder.BindConfiguration("Infrastructure:Persistence:Postgres"));
        collection.AddSingleton<IDataSourcePlugin, MappingPlugin>();

        collection.AddPlatformMigrations(typeof(IAssemblyMarker).Assembly);
        collection.AddHostedService<MigrationRunnerService>();

        // TODO: add repositories
        // collection.AddScoped<IPersistenceContext, PersistenceContext>();
        collection.AddScoped<IUserRepository, UserRepository>();
        collection.AddScoped<IEventRepository, EventRepository>();
        collection.AddScoped<IDonateRepository, DonateRepository>();
        collection.AddScoped<IOrganizatorRepository, OrganizatorRepository>();
        collection.AddScoped<ICollaborationRepository, CollaborationRepository>();
        return collection;
    }
}