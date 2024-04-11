namespace HelpHub.Infrastructure.Persistence.Utils;

public class Generator
{
    private static readonly Random Random = new Random();

    public static string GenerateRandomId(int length)
    {
        const string characters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        char[] id = new char[length];
        for (int i = 0; i < length; i++)
        {
            id[i] = characters[Random.Next(characters.Length)];
        }

        return new string(id);
    }
}