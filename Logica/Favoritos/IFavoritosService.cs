using Logica.Favoritos.DTOs;
using System.Collections.Generic;

namespace Logica.Favoritos
{


    public interface IFavoritosService
    {
        MarkersDTO Create(MarkersDTO model);
        IEnumerable<MarkersDTO> Listar();
        MarkersDTO GetById(int id);

        void Delete(int id);

    }
}
