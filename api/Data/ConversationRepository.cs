using api.Interfaces;
using api.Models;
using api.Services;
using Microsoft.Extensions.Options;
using api.Dtos;

namespace api.Data;

public class ConversationRepository : MongoService<Conversation>, IConversationRepository
{
    public ConversationRepository(IOptions<DatabaseSettings> databaseSettings) : base(databaseSettings)
    {
    }

    public async Task<Conversation> CreateConversation(NewConversation newConversation)
    {
        var now = DateTime.Now;
        
        var conversation = new Conversation{
            Created_at = now,
            Modified_at = now,
            Label = newConversation.Label,
            Topic = newConversation.Topic
        };

        await this.CreateAsync(conversation);

        return conversation;
    }

    public Task<bool> DeleteConversation(string id)
    {
        throw new NotImplementedException();
    }

    public Task<Conversation> GetConversation(string id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Conversation>> GetConversations()
    {
        return await this.GetAsync();
    }

    public Task<bool> UpdateConversation(string id, NewConversation newConversation)
    {
        throw new NotImplementedException();
    }
}