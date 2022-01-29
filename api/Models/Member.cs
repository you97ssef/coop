namespace api.Models;

class Member
{
    public string? Id { get; set; }
    public string? Fullname { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public DateTime Created_at { get; set; }
}