namespace HelpHub.Application.Models.Dtos;

public record OrganizatorResponse(
    int OrganizatorId,
    string Name,
    string Description,
    string Contacts);