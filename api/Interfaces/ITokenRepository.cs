using api.Models;

namespace api.Interfaces;

public interface ITokenRepository
{
    Task<Token?> Get(string? member_id);
    Task Add(Token node);
    Task Remove(Token node);
}