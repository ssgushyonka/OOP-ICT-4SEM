namespace HelpHub.Infrastructure.Persistence.Configurations;

using HelpHub.Infrastructure.Persistence.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class DonateEntityConfiguration : IEntityTypeConfiguration<DonateEntity>
{
    public void Configure(EntityTypeBuilder<DonateEntity> builder)
    {
        builder.ToTable("donates");
        builder.HasKey(u => u.EventId);
    }
}