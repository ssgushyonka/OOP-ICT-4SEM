namespace HelpHub.Application.Models.Dtos;

public record EventResponse(
    int EventId,
    string Name,
    string Location,
    int OrganizatorId,
    DateTime StartDate,
    DateTime EndDate);