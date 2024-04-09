using HelpHub.Application.Contracts.ServiceInterfaces;
using HelpHub.Application.Models.User;
using HelpHub.Infrastructure.Persistence.Repositories;

namespace HelpHub.Application.Service;

public class UserService : IUserService
{
    private readonly UserRepository _userRepository;

    public UserService(UserRepository userRepository, CollaborationRepository collaborationRepository)
    {
        _userRepository = userRepository;
    }

    public async Task Create(UserModel userModel)
    {
        await _userRepository.CreateUser(userModel);
    }

    public Task<UserModel?> GetUser(string userId)
    {
        return Task.FromResult(_userRepository.FindUserById(userId).Result);
    }

    public async Task DeleteUser(string userId)
    {
        var userModel = _userRepository.FindUserById(userId);
        await _userRepository.DeleteUser(await userModel ?? throw new InvalidOperationException());
    }

    public string? GetUserName(string userId)
    {
        return _userRepository.FindUserById(userId).Result?.GetName();
    }

    public string? GetUserEmail(string userId)
    {
        return _userRepository.FindUserById(userId).Result?.GetEmail();
    }

    public async Task UpdateName(string userId, string newName)
    {
        var userModel = _userRepository.FindUserById(userId).Result;
        if (userModel != null)
        {
            var newUserModel = UserModel.Builder()
                .UserId(userModel.UserId)
                .Name(newName)
                .Email(userModel.GetEmail())
                .Role(userModel.GetRole())
                .Password(userModel.GetPassword())
                .Build();
            await _userRepository.UpdateUser(newUserModel);
        }
    }

    public async void UpdateEmail(string userId, string newEmail)
    {
        var userModel = _userRepository.FindUserById(userId).Result;
        if (userModel != null)
        {
            var newUserModel = UserModel.Builder()
                .UserId(userModel.UserId)
                .Name(userModel.GetName())
                .Email(newEmail)
                .Role(userModel.GetRole())
                .Password(userModel.GetPassword())
                .Build();
            await _userRepository.UpdateUser(newUserModel);
        }
    }

    public string? GetUserLastName(string userId)
    {
        return _userRepository.FindUserById(userId).Result?.GetEmail();
    }

    public async void UpdateLastName(string userId, string newEmail)
    {
        var userModel = _userRepository.FindUserById(userId).Result;
        if (userModel != null)
        {
            var newUserModel = UserModel.Builder()
                .UserId(userModel.UserId)
                .Name(userModel.GetName())
                .Email(newEmail)
                .Role(userModel.GetRole())
                .Password(userModel.GetPassword())
                .Build();
            await _userRepository.UpdateUser(newUserModel);
        }
    }

    public async void UpdatePassword(string userId, string newPassword)
    {
        var userModel = _userRepository.FindUserById(userId).Result;
        if (userModel != null)
        {
            var newUserModel = UserModel.Builder()
                .UserId(userModel.UserId)
                .Name(userModel.GetName())
                .Email(userModel.GetEmail())
                .Role(userModel.GetRole())
                .Password(newPassword)
                .Build();
            await _userRepository.UpdateUser(newUserModel);
        }
    }
}