using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProyectoSistemaUsuarios.Models;
using ProyectoSistemaUsuarios.Servicios;

namespace ProyectoSistemaUsuarios.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly UserManager<Usuario> userManager;
        private readonly SignInManager<Usuario> signInManager;

        public UsuarioController(UserManager<Usuario> userManager, SignInManager<Usuario> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

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
            //SE INSTANCIA UN USUARIO Y SE LE ENVIA LOS DATOS, MENOS LA PASSWORD
            var usuario = new Usuario();
            usuario.Correo = modelo.Correo;
            usuario.Cedula = modelo.Cedula;
            usuario.Apellidos = modelo.Apellidos;
            usuario.Nombre = modelo.Nombre;
            usuario.idRol = modelo.idRol;


            //VERIFICAR QUE LA CONTRASEÑA SEA IGUALES
            if (modelo.Contrasena != modelo.ConfirmarContrasena)
            {
                return View(modelo);
            }
             
            //UTILIZANDO EL USUARIOSTORE SE CREA EL USUARIO, PASANDO EL USUARIO Y CONTRASEÑA
            var resultado = await userManager.CreateAsync(usuario, password: modelo.Contrasena);

            if (resultado.Succeeded)
            {
                return RedirectToAction("Login", "Usuario");
            }
            else
            {
                return View(modelo);
            }

        }

    }
}
