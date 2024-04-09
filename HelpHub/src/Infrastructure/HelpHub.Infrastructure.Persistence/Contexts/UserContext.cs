using HelpHub.Infrastructure.Persistence.Entity;

namespace HelpHub.Infrastructure.Persistence.Contexts;

using Microsoft.EntityFrameworkCore;

public class UserContext : DbContext
{
    public UserContext() { }

    public UserContext(DbContextOptions options) : base(options) { }

    public required DbSet<UserEntity> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserContext).Assembly);

        // Добавляем настройки для сущности User
        modelBuilder.Entity<UserEntity>().HasKey(u => u.UserId); // Определяем поле ID как первичный ключ
        modelBuilder.Entity<UserEntity>().Property(u => u.Name).IsRequired(); // Устанавливаем обязательность поля Name
        modelBuilder.Entity<UserEntity>().Property(u => u.Email).IsRequired(); // Устанавливаем обязательность поля Email

        // Другие настройки для сущности User
        base.OnModelCreating(modelBuilder);
    }
}
