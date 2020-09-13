using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Res.DomainLayer.Interfaces
{
    public interface IAsyncRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetListAsync();
        Task<IEnumerable<TEntity>> GetListById(int id);
        Task<IEnumerable<TEntity>> GetProductByCategoryAsync(int categoryId);
    }
}
