using System;
using System.Collections.Generic;
using System.Text;

namespace Logica.Favoritos.DTOs
{
    public class MarkersDTO
    {
        public int Id { get; set; }
        public string Fsq_id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public int Ranking { get; set; }
        public string Imagen { get; set; }
        public string Usuario { get; set; }
        public string Categoria { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
