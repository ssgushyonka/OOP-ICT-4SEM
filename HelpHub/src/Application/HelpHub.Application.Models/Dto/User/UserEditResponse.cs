namespace HelpHub.Application.Models.Dtos;

public record UserEditResponse(
    int UserId,
    string Name,
    string? Email,
    string Role,
    string? Password);