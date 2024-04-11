namespace HelpHub.Infrastructure.Persistence.Configurations;

using HelpHub.Infrastructure.Persistence.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class CollaborationEntityConfiguration : IEntityTypeConfiguration<CollaborationEntity>
{
    public void Configure(EntityTypeBuilder<CollaborationEntity> builder)
    {
        builder.ToTable("collaboration");
        builder.HasKey(u => u.EventId);
    }
}