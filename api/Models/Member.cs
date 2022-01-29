namespace api.Models;

public class Member : Model
{
    public string? Fullname { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public DateTime Created_at { get; set; }
}