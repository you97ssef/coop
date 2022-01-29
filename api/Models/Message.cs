namespace api.Models;

public class Message : Model
{
    public string? Content { get; set; }
    public string? Member_id { get; set; }
    public string? Conversation_id { get; set; }
    public DateTime Created_at { get; set; }
    public DateTime Modified_at { get; set; }
}