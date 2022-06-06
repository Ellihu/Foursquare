using Datos.Repositorios;

namespace Datos
{
    public class UnitOfWork : IUnitOfWork
    {
        ApplicationDbContext context { get; }

        public IFavoritosRepository FavoritosRepository { get; }

        public void SaveChanges()
        {
            context.SaveChanges();
        }
        public UnitOfWork(ApplicationDbContext context)
        {
            this.context = context;

            FavoritosRepository = new FavoritosRepository(context);

        }

    }
}
