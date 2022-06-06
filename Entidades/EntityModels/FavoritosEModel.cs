using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidades.EntityModels
{
    [Table("Favoritos")]
    public class FavoritosEModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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
