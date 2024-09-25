using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace ProyectoSistemaUsuarios.Models
{
    public class RegistroUsuarioViewModel
    {

        [Required(ErrorMessage = "Se requiere el campo {0}")]
        public int Cedula { get; set; }

        [Required(ErrorMessage = "Se requiere el campo {0}")]
        [EmailAddress(ErrorMessage = "El campo debe ser un correo electrónico válido")]
        public string Correo { get; set; }

        [Required(ErrorMessage = "Se requiere el campo {0}")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Se requiere el campo {0}")]
        public string Apellidos { get; set; }


        [Required(ErrorMessage = "Se requiere el campo {0}")]
        [Display(Name = "Contraseña")]
        public string Contrasena { get; set; }

        [Display(Name = "Confirmar contraseña")]
        public string ConfirmarContrasena { get; set; }


        [Display(Name = "Rol")]
        public TipoRol idRol { get; set; } = TipoRol.Administrador;
    }
}
