using HelpHub.Infrastructure.Persistence.Entity;

namespace HelpHub.Infrastructure.Persistence.Contexts;

using Microsoft.EntityFrameworkCore;

public class DonateContext : DbContext
{
    public DonateContext() { }

    public DonateContext(DbContextOptions options) : base(options) { }

    public required DbSet<DonateEntity> Donations { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DonateContext).Assembly);

        // Добавляем настройки для сущности Donate
        modelBuilder.Entity<DonateEntity>().HasKey(d => d.DonateId); // Определяем поле Id как первичный ключ
        modelBuilder.Entity<DonateEntity>().Property(d => d.Coin).IsRequired(); // Устанавливаем обязательность поля Coin
        modelBuilder.Entity<DonateEntity>().Property(d => d.DateTime).IsRequired(); // Устанавливаем обязательность поля StartDate
        modelBuilder.Entity<DonateEntity>().Property(d => d.UserId).IsRequired(); // Устанавливаем обязательность поля Donor
        modelBuilder.Entity<DonateEntity>().Property(d => d.EventId).IsRequired(); // Устанавливаем обязательность поля Event

        // Другие настройки для сущности Donate
        base.OnModelCreating(modelBuilder);
    }
}