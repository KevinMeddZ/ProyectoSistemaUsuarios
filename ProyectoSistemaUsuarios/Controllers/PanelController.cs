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

        [HttpGet]
        public async Task<IActionResult> Eliminar(int id)
        {
            //OBTIENE EL ID EL USUARIO LOGEADO
            var usuarioLogueado = ObtenerUsuariologueado();

            //VERIFICA SI ESTÁ LOGUEADO
            if(id == usuarioLogueado)
            {
                ModelState.AddModelError("", "No puedes eliminar tu propio usuario");
                
                return View("Error");

            }

            //OBTIENE EL MODELO DEL USUARIO POR ID
            var modelo = await repositorioUsuarios.ObtenerUsuarioPorId(id);
            //VERIFICA SI ES NULL
            if (modelo == null)
            {
                return RedirectToAction("Index", "Home");
            }

            //SI TODO ESTÁ BIEN, CARGA LA VISTA
            return View(modelo);
        }


        //BORRAR USUARIO DE LA BD
        [HttpPost]
        public async Task<IActionResult> EliminarUsuario(int id)
        {
            //SE OBTIENE EL USUARIO POR ID
            var usuario = await repositorioUsuarios.ObtenerUsuarioPorId(id);

            if (usuario == null)
            {
                return RedirectToAction("UsuarioNoEncontrado", "Home");
            }

            //EJECUTA EL METODO DEL SERVICIO PARA ELIMINAR DE LA BD
            await repositorioUsuarios.Eliminar(id);

            return RedirectToAction("Index");
        }



        private int ObtenerUsuariologueado()
        {
            return int.Parse(User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier).Value);
        }
    }
}
