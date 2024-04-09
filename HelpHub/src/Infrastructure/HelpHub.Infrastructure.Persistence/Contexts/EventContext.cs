using HelpHub.Infrastructure.Persistence.Entity;

namespace HelpHub.Infrastructure.Persistence.Contexts;

using Microsoft.EntityFrameworkCore;

public class EventContext : DbContext
{
    public EventContext() { }

    public EventContext(DbContextOptions options) : base(options) { }

    public required DbSet<EventEntity> Events { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(EventContext).Assembly);

        // Добавляем настройки для сущности Event
        modelBuilder.Entity<EventEntity>().HasKey(e => e.EventId); // Определяем поле ID как первичный ключ
        modelBuilder.Entity<EventEntity>().Property(e => e.Name).IsRequired(); // Устанавливаем обязательность поля Name
        modelBuilder.Entity<EventEntity>().Property(e => e.Location).IsRequired(); // Устанавливаем обязательность поля Location
        modelBuilder.Entity<EventEntity>().Property(e => e.StartDate).IsRequired(); // Устанавливаем обязательность поля StartDate
        modelBuilder.Entity<EventEntity>().HasOne(e => e.OrganizatorId).WithMany().HasForeignKey(e => e.OrganizatorId); // Определяем связь один-ко-многим с сущностью User

        // Другие настройки для сущности Event
        base.OnModelCreating(modelBuilder);
    }
}