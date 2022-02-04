using api.Interfaces;
using api.Models;
using api.Services;
using Microsoft.Extensions.Options;

namespace api.Data;

public class KeyRepository : MongoService<ApiKey>, IKeyRepository
{
    public KeyRepository(IOptions<DatabaseSettings> databaseSettings) : base(databaseSettings) { }

    public async Task Add(ApiKey node)
    {
        await this.CreateAsync(node);
    }

    public async Task<ApiKey?> Get(string id)
    {
        return await this.GetAsync(id);
    }

    public async Task<IEnumerable<ApiKey>> GetAll()
    {
        return await this.GetAsync();
    }

    public async Task Remove(ApiKey node)
    {
        await this.RemoveAsync(node.Id!);
    }

    public async Task Update(ApiKey node)
    {
        await this.UpdateAsync(node.Id!, node);
    }
}