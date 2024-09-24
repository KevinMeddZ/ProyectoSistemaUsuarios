using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProyectoSistemaUsuarios.Models;
using ProyectoSistemaUsuarios.Servicios;

namespace ProyectoSistemaUsuarios.Controllers
{
    public class PanelController : Controller
    {
        private readonly IRepositorioUsuarios repositorioUsuarios;

        public PanelController(IRepositorioUsuarios repositorioUsuarios)
        {
            this.repositorioUsuarios = repositorioUsuarios;
        }

        public async Task<IActionResult> Index()
        {

            var modelo = await repositorioUsuarios.ObtenerUsuarios();

            if (modelo == null)
            {
                return RedirectToAction("Index", "Home");
            }

            return View(modelo);
        }


        [HttpGet]
        public async Task<IActionResult> Editar(int id)
        {
            var usuario = await repositorioUsuarios.ObtenerUsuarioPorId(id);

            if (usuario == null)
            {
                return RedirectToAction("Index", "Home");
            }

            return View(usuario);
        }


        //EDITAR CATEGORIA
        [HttpPost]
        public async Task<IActionResult> Editar(Usuario usuarioEditar)
        {

            //SE OBTIENE EL USUARIO
            var usuario = await repositorioUsuarios.ObtenerUsuarioPorId(usuarioEditar.id);

            //SE VERIFICA SI ES NULO
            if (usuario == null)
            {
                return RedirectToAction("Index", "Home");
            }

            //SE ENVIA EL ID DEL USUARIO
            usuarioEditar.id = usuario.id;

            //SERVICIO PARA ACTUALIZAR EL USUARIO
            await repositorioUsuarios.ActualizarUsuario(usuarioEditar);

            
            return RedirectToAction("Index");

        }

        
    }
}
