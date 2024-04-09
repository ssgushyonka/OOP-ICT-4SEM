namespace HelpHub.Application.Models.Dtos.User;

public record UserResponse(
    string UserId,
    string Name,
    string Email,
    string Role,
    string Password);