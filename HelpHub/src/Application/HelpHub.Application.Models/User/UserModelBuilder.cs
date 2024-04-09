namespace HelpHub.Application.Models.User;

public class UserModelBuilder
{
    private string? _userid;
    private string? _name;
    private string? _email;
    private string? _password;
    private string? _role;

    public UserModelBuilder UserId(string? userid)
    {
        _userid = userid;
        return this;
    }

    public UserModelBuilder Name(string? name)
    {
        _name = name;
        return this;
    }

    public UserModelBuilder Email(string? email)
    {
        _email = email;
        return this;
    }

    public UserModelBuilder Password(string? password)
    {
        _password = password;
        return this;
    }

    public UserModelBuilder Role(string? role)
    {
        _role = role;
        return this;
    }

    public UserModel Build()
    {
        return new UserModel(_userid, _name, _email, _role, _password);
    }
}