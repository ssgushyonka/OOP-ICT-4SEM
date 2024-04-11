namespace HelpHub.Infrastructure.Persistence.Configurations;

using HelpHub.Infrastructure.Persistence.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class EventEntityConfiguration : IEntityTypeConfiguration<EventEntity>
{
    public void Configure(EntityTypeBuilder<EventEntity> builder)
    {
        builder.ToTable("events");
        builder.HasKey(u => u.EventId);
    }
}