using api.Models;

namespace api.Interfaces;

interface IConversationRepository
{
    Task<Conversation> GetConversation(string id);
    Task<IEnumerable<Conversation>> GetConversations();
    Task<bool> CreateConversation(string topic, string label);
    Task<bool> UpdateConversation(string id, string topic, string label);
    Task<bool> DeleteConversation(string id);
}