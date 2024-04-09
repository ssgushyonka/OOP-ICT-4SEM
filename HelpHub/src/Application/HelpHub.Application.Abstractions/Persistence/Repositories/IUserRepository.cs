using HelpHub.Application.Models.User;
namespace HelpHub.Application.Abstractions.Persistence.Repositories;

public interface IUserRepository
{
    Task<UserModel?> FindUserById(string userId);

    Task CreateUser(UserModel userModel);

    Task UpdateUser(UserModel userModel);

    Task DeleteUser(UserModel userModel);
}