namespace HelpHub.Application.Models.Dtos;

public record DonateResponse(
    int DonateId,
    int Coin,
    DateTime DateTime,
    int UserId,
    int EventId);