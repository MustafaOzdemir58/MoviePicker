using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviePicker.Infrastructure.PostgreSql
{
    public interface IPostgreSqlRepository<T> where T : class, new()
    {
        Task<T> GetById(string query, object param = null);
        Task<IEnumerable<T>> GetAll(string query, object param = null);
        Task<int> Add(string query, object param = null);
        Task<int> Update(string query, object param = null);
        Task<int> Delete(string query, object param = null);
    }
}
