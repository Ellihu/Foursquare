using System;
using System.Collections.Generic;
using System.Text;

namespace Logica.Favoritos.Models
{
    public class FiltrosModel
    {
        public string Buscar { get; set; }
        public Ubicacion Ubicacion { get; set; }
        public int Radio { get; set; }
    }

    public class Ubicacion
    {
        public string Latitud { get; set; }
        public string Longitud { get; set; }
    }
}
