using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Cargo.BusinessLayer.Abstract
{
    public interface IGenericService<T> where T : class
    {
        Task<List<T>> TGetAllAsync();
        Task<T> TGetByIdAsync(int id);
        Task TCreateAsync(T entity);
        Task TUpdateAsync(T entity);
        Task TRemoveAsync(int id);
    }
}
