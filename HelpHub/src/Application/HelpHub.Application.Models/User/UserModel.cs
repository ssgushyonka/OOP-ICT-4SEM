namespace HelpHub.Application.Models.User;

public class UserModel
{
    public string? UserId { get; set; }

    private string? Name { get; set; }

    private string? Email { get; set; }

    private string? Role { get; set; }

    private string? Password { get; set; }

    public UserModel(
        string? userId,
        string? name,
        string? email,
        string? role,
        string? password)
    {
        UserId = userId;
        Name = name;
        Email = email;
        Password = password;
        Role = role;
    }

    public static UserModelBuilder Builder()
    {
        return new UserModelBuilder();
    }

    public string? GetName()
    {
        return Name;
    }

    public string? GetEmail()
    {
        return Email;
    }

    public string? GetPassword()
    {
        return Password;
    }

    public string? GetRole()
    {
        return Role;
    }
}