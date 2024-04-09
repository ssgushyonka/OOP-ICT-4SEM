namespace HelpHub.Application.Models.Donate;

public class DonateModelBuilder
{
    private string? _donateId;
    private string? _coin;
    private DateTime? _dateTime;
    private string? _userId;
    private string? _eventId;

    public DonateModelBuilder DonateId(string? donateId)
    {
        _donateId = donateId;
        return this;
    }

    public DonateModelBuilder Coin(string? coin)
    {
        _coin = coin;
        return this;
    }

    public DonateModelBuilder DateTime(DateTime dateTime)
    {
        _dateTime = dateTime;
        return this;
    }

    public DonateModelBuilder UserId(string? userId)
    {
        _userId = userId;
        return this;
    }

    public DonateModelBuilder EventId(string? eventId)
    {
        _eventId = eventId;
        return this;
    }

    public DonateModel Build()
    {
        return new DonateModel(_donateId, _coin, _userId, _eventId, _dateTime);
    }
}