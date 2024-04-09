namespace HelpHub.Application.Models.Dtos;

public record CollaborationResponse(
    int CollaborationId,
    int UserId,
    int EventId);