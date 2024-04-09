using HelpHub.Infrastructure.Persistence.Entity;

namespace HelpHub.Infrastructure.Persistence.Contexts;

using Microsoft.EntityFrameworkCore;

public class OrganizationContext : DbContext
{
    public OrganizationContext() { }

    public OrganizationContext(DbContextOptions options) : base(options) { }

    public required DbSet<OrganizatorEntity> Organizations { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(OrganizationContext).Assembly);

        // Добавляем настройки для сущности Organization
        modelBuilder.Entity<OrganizatorEntity>().HasKey(o => o.OrganizatorId); // Определяем поле ID как первичный ключ
        modelBuilder.Entity<OrganizatorEntity>().Property(o => o.Name).IsRequired(); // Устанавливаем обязательность поля Name
        modelBuilder.Entity<OrganizatorEntity>().Property(o => o.Description); // Поле Description необязательное
        modelBuilder.Entity<OrganizatorEntity>().Property(o => o.Contacts); // Поле Contacts необязательное

        // Другие настройки для сущности Organization
        base.OnModelCreating(modelBuilder);
    }
}