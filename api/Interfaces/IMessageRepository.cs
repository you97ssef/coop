using api.Models;

namespace api.Interfaces;

public interface IMessageRepository : IRepository<Message>
{
    public Task<IEnumerable<Message>> GetConversationMessages(string conversation_id);
}