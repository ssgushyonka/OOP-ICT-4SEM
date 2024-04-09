namespace HelpHub.Application.Models.Dtos;

public record OrganizatorUpdateResponse(
    int OrganizatorId,
    string Name,
    string Description,
    string Contacts);