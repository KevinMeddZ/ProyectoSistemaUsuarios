using Microsoft.AspNetCore.Mvc;
using ProyectoSistemaUsuarios.Models;

namespace ProyectoSistemaUsuarios.Controllers
{
    public class UsuarioController : Controller
    {
        public IActionResult Registro()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }




        [HttpPost]
        public async Task<IActionResult> Registro(RegistroUsuarioViewModel modelo)
        {
            if (!ModelState.IsValid)
            {
                return View(modelo);
            }

            //LOGICA PARA INGRESAR EL USUARIO A LA BD



            return RedirectToAction("Index", "Home");
        }

    }
}
