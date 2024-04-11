using HelpHub.Application.Abstractions.Persistence.Repositories;
using HelpHub.Application.Models.User;
using HelpHub.Infrastructure.Persistence.Contexts;
using HelpHub.Infrastructure.Persistence.Entity;
using HelpHub.Infrastructure.Persistence.Utils;
using Microsoft.EntityFrameworkCore;

namespace HelpHub.Infrastructure.Persistence.Repositories;

    public class UserRepository(ApplicationDbContext context) : IUserRepository
{
    private const int IdLength = 10;

    public async Task<UserModel?> FindUserById(string userId)
    {
        var userEntity = await context.Users.FirstOrDefaultAsync(u => u.UserId == userId);
        return userEntity != null ? MapEntityToModel(userEntity) : null;
    }

    public async Task CreateUser(UserModel userModel)
    {
        var newUserEntity = new UserEntity
        {
            UserId = Generator.GenerateRandomId(IdLength),
            Name = userModel.GetName(),
            Email = userModel.GetEmail(),
            Password = userModel.GetPassword(),
            Role = userModel.GetRole(),
        };

        context.Users.Add(newUserEntity);
        await context.SaveChangesAsync();
    }

    public async Task UpdateUser(UserModel userModel)
    {
        var userEntityToUpdate = MapModelToEntity(userModel);
        context.Entry(userEntityToUpdate).State = EntityState.Modified;
        await context.SaveChangesAsync();
    }

    public async Task DeleteUser(UserModel userModel)
    {
        var userEntityToDelete = MapModelToEntity(userModel);
        context.Users.Remove(await userEntityToDelete);
        await context.SaveChangesAsync();
    }

    private UserModel MapEntityToModel(UserEntity user)
    {
        return UserModel.Builder()
            .UserId(user.UserId)
            .Name(user.Name)
            .Email(user.Email)
            .Build();
    }

    private Task<UserEntity> MapModelToEntity(UserModel userModel)
    {
        return Task.FromResult(new UserEntity
        {
            Name = userModel.GetName(),
            Email = userModel.GetEmail(),
            Password = userModel.GetPassword(),
            UserId = userModel.UserId,
        });
    }
}
