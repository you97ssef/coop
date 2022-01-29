using api.Models;
using api.Dtos;

namespace api.Interfaces;

public interface IConversationRepository
{
    Task<Conversation> GetConversation(string id);
    Task<IEnumerable<Conversation>> GetConversations();
    Task<Conversation> CreateConversation(NewConversation newConversation);
    Task<bool> UpdateConversation(string id, NewConversation newConversation);
    Task<bool> DeleteConversation(string id);
}