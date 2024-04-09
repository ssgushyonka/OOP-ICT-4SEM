using HelpHub.Infrastructure.Persistence.Entity;

namespace HelpHub.Infrastructure.Persistence.Contexts;

using Microsoft.EntityFrameworkCore;

public class CollaborationContext : DbContext
{
    public CollaborationContext() { }

    public CollaborationContext(DbContextOptions<CollaborationContext> options) : base(options) { }

    public required DbSet<CollaborationEntity> Collaborations { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CollaborationContext).Assembly);

        modelBuilder.Entity<CollaborationEntity>().HasKey(c => c.CollaborationId);
        modelBuilder.Entity<CollaborationEntity>().Property(d => d.UserId).IsRequired();
        modelBuilder.Entity<CollaborationEntity>().Property(d => d.EventId).IsRequired();

        base.OnModelCreating(modelBuilder);
    }
}