using HelpHub.Application.Models.User;

namespace HelpHub.Application.Contracts.ServiceInterfaces;

public interface IUserService
{
     Task Create(UserModel userModel);

     Task<UserModel?> GetUser(string userId);

     Task DeleteUser(string userId);

     string? GetUserName(string userId);

     string? GetUserEmail(string userId);

     void UpdateEmail(string userId, string newEmail);

     Task UpdateName(string userId, string newName);

     void UpdatePassword(string userId, string newPassword);
}