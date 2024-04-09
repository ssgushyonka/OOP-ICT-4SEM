namespace HelpHub.Application.Models.Donate;

public class DonateModel
{
    private string? DonateId { get; set; }

    private string? Coin { get; set; }

    private DateTime? DateTime { get; set; }

    private string? UserId { get; set; }

    private string? EventId { get; set; }

    public DonateModel(
        string? donateId,
        string? coin,
        string? userId,
        string? eventId,
        DateTime? dateTime)
    {
        DonateId = donateId;
        Coin = coin;
        DateTime = dateTime;
        UserId = userId;
        EventId = eventId;
    }

    public static DonateModelBuilder Builder()
    {
        return new DonateModelBuilder();
    }

    public string? GetDonateId()
    {
        return DonateId;
    }

    public string? GetCoin()
    {
        return Coin;
    }

    public DateTime? GetDateTime()
    {
        return DateTime;
    }

    public string? GetUserId()
    {
        return UserId;
    }

    public string? GetEventId()
    {
        return EventId;
    }
}