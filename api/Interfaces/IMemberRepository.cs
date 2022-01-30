using api.Models;
using api.Dtos;

namespace api.Interfaces;

public interface IMemberRepository : IRepository<Member>
{
    Task<Member?> Login(Login login);
}