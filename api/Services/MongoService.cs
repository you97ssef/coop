using Microsoft.Extensions.Options;
using MongoDB.Driver;
using api.Models;
using api.Data;

namespace api.Services;

public class MongoService<T> where T : Model
{
    protected readonly IMongoCollection<T> _collection;

    public MongoService(IOptions<DatabaseSettings> databaseSettings)
    {
        var mongoClient = new MongoClient(databaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(databaseSettings.Value.DatabaseName);

        _collection = mongoDatabase.GetCollection<T>(typeof(T).Name + "s");
    }

    protected async Task<List<T>> GetAsync() => await _collection.Find(_ => true).ToListAsync();

    protected async Task<T?> GetAsync(string id) => await _collection.Find(x => x.Id == id).FirstOrDefaultAsync();

    protected async Task CreateAsync(T newNode) => await _collection.InsertOneAsync(newNode);

    protected async Task UpdateAsync(string id, T updatedNode) => await _collection.ReplaceOneAsync(x => x.Id == id, updatedNode);

    protected async Task RemoveAsync(string id) => await _collection.DeleteOneAsync(x => x.Id == id);
}