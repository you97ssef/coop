using api.Models;

namespace api.Interfaces;

public interface IMessageRepository
{
    Task<Message> GetMessage(string id);
    Task<IEnumerable<Message>> GetConversationMessages(string conversationId);
    Task<bool> CreateMessage(string content, string memberId);
    Task<bool> UpdateMessage(string id, string content);
    Task<bool> DeleteMessage(string id);
}