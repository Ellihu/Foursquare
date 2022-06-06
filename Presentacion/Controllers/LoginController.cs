using Datos;
using Entidades.EntityModels;
using Entidades.ViewModels;
using Logica;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Presentacion.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly AccountService _accountService;

        static String PATH = "~/Views/Login/Index.cshtml";

        public LoginController(IUnitOfWork unitOfWork)
        {
            _accountService = new AccountService(unitOfWork);

        }

        public IActionResult Index()
        {
            return View();
        }


        public async Task<IActionResult> Login(AuthenticateModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    throw new Exception("Verifique sus datos.");

                UsuariosModel user = _accountService.Authenticate(model.UserName, model.Password);

                if (user == null)
                    throw new Exception("Usuario o contraseña incorrectos");

                var claims = new List<Claim> {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                //new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Actor,String.Format("{0}", user.FirstName))
                };

                var grandmaIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var userPrincipal = new ClaimsPrincipal(new[] { grandmaIdentity });

                await HttpContext.SignInAsync(userPrincipal);

                return RedirectToAction("Index", "Places");

            }
            catch (Exception ex)
            {
                TempData["LoginError"] = ex.Message;
                return View(PATH, model);
            }


        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index");

        }
        public IActionResult GumtreePost(string user, string pasword)
        {
            string atsakas = "";
            return Json(atsakas);
        }



    }


    public class CookieDetails
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
