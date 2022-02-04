using api.Interfaces;
using api.Models;
using api.Services;
using Microsoft.Extensions.Options;

namespace api.Data;

public class ConversationRepository : MongoService<Conversation>, IConversationRepository
{
    public ConversationRepository(IOptions<DatabaseSettings> databaseSettings) : base(databaseSettings) { }

    public async Task Add(Conversation node)
    {
        await this.CreateAsync(node);
    }

    public async Task Remove(Conversation node)
    {
        await this.RemoveAsync(node.Id!);
    }

    public async Task<Conversation?> Get(string id)
    {
        return await this.GetAsync(id);
    }

    public async Task<IEnumerable<Conversation>> GetAll()
    {
        return await this.GetAsync();
    }

    public async Task Update(Conversation node)
    {
        await this.UpdateAsync(node.Id!, node);
    }
}