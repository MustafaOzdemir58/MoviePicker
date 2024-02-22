
namespace MoviePicker.Infrastructure.PostgreSql
{
    public interface IPostgreSqlRepository1<T>
    {
        Task Add(T entity);
        Task Delete(int id);
        Task<List<T>> GetAll();
        Task<T> GetById(int id);
        Task Update(T entity);
    }
}