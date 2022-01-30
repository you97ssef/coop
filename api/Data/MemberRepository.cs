using api.Interfaces;
using api.Models;
using api.Services;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using api.Dtos;

namespace api.Data;

public class MemberRepository : MongoService<Member>, IMemberRepository
{
    public MemberRepository(IOptions<DatabaseSettings> databaseSettings) : base(databaseSettings) { }

    public async Task Add(Member node)
    {
        await this.CreateAsync(node);
    }

    public async Task Remove(Member node)
    {
        await this.RemoveAsync(node.Id!);
    }

    public async Task<Member?> Get(string id)
    {
        return await this.GetAsync(id);
    }

    public async Task<IEnumerable<Member>> GetAll()
    {
        return await this.GetAsync();
    }

    public async Task Update(Member node)
    {
        await this.UpdateAsync(node.Id!, node);
    }

    public async Task<Member?> Login(Login login)
    {
        return await _collection.Find(x => x.Email == login.Email && x.Password == login.Password).FirstOrDefaultAsync();
    }
}