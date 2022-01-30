using api.Interfaces;
using api.Models;
using api.Services;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace api.Data;

public class MessageRepository : MongoService<Message>, IMessageRepository
{
    public MessageRepository(IOptions<DatabaseSettings> databaseSettings) : base(databaseSettings) { }

    public async Task Add(Message node)
    {
        await this.CreateAsync(node);
    }

    public async Task Remove(Message node)
    {
        await this.RemoveAsync(node.Id!);
    }

    public async Task<Message?> Get(string id)
    {
        return await this.GetAsync(id);
    }

    public async Task<IEnumerable<Message>> GetAll()
    {
        return await this.GetAsync();
    }

    public async Task<IEnumerable<Message>> GetConversationMessages(string conversation_id)
    {
        return await this._collection.Find(x => x.Conversation_id == conversation_id).ToListAsync();
    }

    public async Task Update(Message node)
    {
        await this.UpdateAsync(node.Id!, node);
    }
}