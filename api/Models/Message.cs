namespace api.Models;

class Message
{
    public string? Id { get; set; }
    public string? Content { get; set; }
    public string? Member_id { get; set; }
    public string? Conversation_id { get; set; }
    public DateTime Created_at { get; set; }
    public DateTime Modified_at { get; set; }
}