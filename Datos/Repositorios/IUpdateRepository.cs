using System;
using System.Collections.Generic;

namespace Datos.Repositorios
{

    public interface IUpdateRepository<T>
    {
        T Update(T entity);
        void Update(IEnumerable<T> entity);
    }

}
