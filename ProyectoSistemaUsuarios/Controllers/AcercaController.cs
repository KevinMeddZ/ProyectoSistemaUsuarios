using Microsoft.AspNetCore.Mvc;
using ProyectoSistemaUsuarios.Models;

namespace ProyectoSistemaUsuarios.Controllers
{
    public class AcercaController : Controller
    {
        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}
