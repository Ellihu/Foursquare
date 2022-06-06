using Datos.Repositorios;
using Entidades.EntityModels;

namespace Datos
{
    public interface IFavoritosRepository :
       ICreateRepository<FavoritosEModel>,
       IUpdateRepository<FavoritosEModel>,
       IReadRepository<FavoritosEModel>,
       IRemoveRepository<FavoritosEModel>
    {
    }
}