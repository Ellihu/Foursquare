using Logica.Favoritos.Models;
using System.Threading.Tasks;

namespace Logica.Favoritos
{
    public interface IFoursquarePlacesService
    {
        Task<string> Buscar(FiltrosModel filtros);
        Task<string> GetDetails(string placeId);
        Task<string> GetPhotos(string placeId);


    }
}
