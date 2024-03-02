namespace HelpHub.Application.Models.DomainEntities;

public class Event
{
    public int ID { get; set; }
    public string Name { get; set; }
    public List<User> Users { get; set; }
    public string Location { get; set; }
    public User Organizator { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}