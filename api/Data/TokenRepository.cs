using api.Interfaces;
using api.Models;
using api.Services;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace api.Data;

public class TokenRepository : MongoService<Token>, ITokenRepository
{
    public TokenRepository(IOptions<DatabaseSettings> databaseSettings) : base(databaseSettings) { }

    public async Task Add(Token node)
    {
        await this.CreateAsync(node);
    }

    public async Task Remove(Token node)
    {
        await this.RemoveAsync(node.Id!);
    }

    public async Task<Token?> Get(string? member_id)
    {
        return await _collection.Find(x => x.Member_id == member_id).FirstOrDefaultAsync();
    }
}