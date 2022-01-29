namespace api.Models;

public class Conversation : Model
{
    public string? Label { get; set; }
    public string? Topic { get; set; }
    public DateTime Created_at { get; set; }
    public DateTime Modified_at { get; set; }
}