namespace api.Interfaces;

public interface IRepository<T>
{
    Task<T?> Get(string id);
    Task<IEnumerable<T>> GetAll();
    Task Add(T node);
    Task Update(T node);
    Task Remove(T node);
}