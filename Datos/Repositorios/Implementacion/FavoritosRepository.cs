using Entidades.EntityModels;

namespace Datos.Repositorios
{
    public class FavoritosRepository : GenericRepository<FavoritosEModel>, IFavoritosRepository
    {
        public FavoritosRepository(ApplicationDbContext context) : base(context)
        {
        }

    }
}
