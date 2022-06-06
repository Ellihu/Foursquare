using Logica.Services;
using Microsoft.AspNetCore.Http;

namespace Presentacion.Servicios
{
    public class WebUserLoggedService : IUserLoggedService
    {
        private readonly string _username;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public WebUserLoggedService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _username = _httpContextAccessor.HttpContext.User.Identity.Name;
        }


        public string GetUserName()
        {
            return _username;
        }

    }

}
