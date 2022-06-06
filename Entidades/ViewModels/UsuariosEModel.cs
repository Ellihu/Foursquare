using System;

namespace Entidades.ViewModels
{
    public partial class UsuariosModel 
    {
      
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string CellPhone { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Nullable<System.DateTime> LastLoginDate { get; set; }
        public bool Activo { get; set; }


    }
}
