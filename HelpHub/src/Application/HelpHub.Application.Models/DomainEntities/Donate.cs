namespace HelpHub.Application.Models.DomainEntities;

public class Donate
{
    public int ID { get; set; }
    public string Coin { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public User Donor { get; set; }
    public Event Event { get; set; }
}