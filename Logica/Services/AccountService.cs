using Datos;
using Entidades.ViewModels;
using System;

namespace Logica
{
    public class AccountService
    {
        private readonly IUnitOfWork _unitOfWork;
        public AccountService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public UsuariosModel Authenticate(String userName, String passwordd)
        {
            UsuariosModel user = GetUsetTest(userName, passwordd);

            return user;
        }

        

        public static UsuariosModel GetUsetTest(string UserName, string password)
        {
            return new UsuariosModel()
            {
                UserName = UserName,
                FirstName = "Usuario",
                Id = -1,
                LastLoginDate = DateTime.Now,
                LastName = "Prueba " + UserName,
                Email = "test@email.com",
                Activo = true,
            };

        }
    }
}
