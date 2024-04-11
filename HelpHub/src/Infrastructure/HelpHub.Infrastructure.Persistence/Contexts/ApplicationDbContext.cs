using HelpHub.Infrastructure.Persistence.Configurations;
using HelpHub.Infrastructure.Persistence.Entity;
using Microsoft.EntityFrameworkCore;

namespace HelpHub.Infrastructure.Persistence.Contexts;

public sealed class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
        Database.EnsureCreated();
    }

    public ApplicationDbContext(DbContextOptions options) : base(options) { }

    public required DbSet<UserEntity> Users { get; set; }

    public required DbSet<EventEntity> Events { get; set; }

    public required DbSet<DonateEntity> Donatess { get; set; }

    public required DbSet<CollaborationEntity> Collaboration { get; set; }

    public required DbSet<OrganizatorEntity> Organizator { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

        modelBuilder.ApplyConfiguration(new UserEntityConfiguration());
        modelBuilder.ApplyConfiguration(new EventEntityConfiguration());
        modelBuilder.ApplyConfiguration(new DonateEntityConfiguration());
        modelBuilder.ApplyConfiguration(new CollaborationEntityConfiguration());
        modelBuilder.ApplyConfiguration(new OrganizatorEntityConfiguration());

        base.OnModelCreating(modelBuilder);
    }
}