using api.Models;

namespace api.Interfaces;

public interface IMemberRepository
{
    Task<Member> GetMember(string id);
    Task<IEnumerable<Member>> GetMembers();
    Task<bool> Register(string fullname, string username, string password);
    Task<Token> Login(string username, string password);
    Task<bool> DeleteMember(string id);
}