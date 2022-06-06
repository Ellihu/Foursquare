using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Datos.Repositorios
{
   
    public interface IRemoveRepository<T>
    {
        void Remove(T t);
        void Remove(IEnumerable<T> t);

    }
}
