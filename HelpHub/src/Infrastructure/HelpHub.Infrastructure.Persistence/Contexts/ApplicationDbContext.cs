using HelpHub.Infrastructure.Persistence.Configurations;
using HelpHub.Infrastructure.Persistence.Entity;
using Microsoft.EntityFrameworkCore;

namespace HelpHub.Infrastructure.Persistence.Contexts;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext() {}
    public ApplicationDbContext(DbContextOptions options) : base(options) { }
    
    public required DbSet<UserEntity> users { get; set; }
    public required DbSet<EventEntity> events { get; set; }
    public required DbSet<DonateEntity> donatess { get; set; }
    public required DbSet<CollaborationEntity> collaboration { get; set; }
    public required DbSet<OrganizatorEntity> organizator { get; set; }
    
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