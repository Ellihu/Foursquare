using System.Collections.Generic;

namespace Datos.Repositorios
{
    public interface ICreateRepository<T>
    {
        T Add(T entity);
        void Add(IEnumerable<T> t);
    }


}
