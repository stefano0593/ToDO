namespace Todo.Application.Settings;

public class JwtSettings
{
    public string SigningKey { get; set; } = null!;
    public string Issuer { get; set; } = null!;
    public List<string> Audience { get; set; } = new();
}