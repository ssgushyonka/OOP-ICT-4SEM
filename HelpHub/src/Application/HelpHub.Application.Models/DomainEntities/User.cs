namespace HelpHub.Application.Models.DomainEntities;

public class User
{
    public int ID { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Role { get; set; }
    public string Pass { get; set; }
}