namespace Datos
{
    public interface IUnitOfWork
    {
        public IFavoritosRepository FavoritosRepository { get; }
        public void SaveChanges();

    }

}
