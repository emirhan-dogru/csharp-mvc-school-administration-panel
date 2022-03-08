using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcCrudProje.Bussiness.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        List<T> get();
        void create(T entity);
        void update(T entity);
        void delete(int id);
    }
}
