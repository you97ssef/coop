namespace api.Models;

class Conversation
{
    public string? Id { get; set; }
    public string? Label { get; set; }
    public string? Topic { get; set; }
    public DateTime Created_at { get; set; }
    public DateTime Modified_at { get; set; }
}