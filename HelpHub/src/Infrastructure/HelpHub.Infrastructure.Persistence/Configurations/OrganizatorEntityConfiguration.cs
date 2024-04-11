namespace HelpHub.Infrastructure.Persistence.Configurations;

using HelpHub.Infrastructure.Persistence.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class OrganizatorEntityConfiguration : IEntityTypeConfiguration<OrganizatorEntity>
{
    public void Configure(EntityTypeBuilder<OrganizatorEntity> builder)
    {
        builder.ToTable("organizator");
        builder.HasKey(u => u.OrganizatorId);
    }
}