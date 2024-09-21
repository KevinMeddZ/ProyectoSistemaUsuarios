using System.ComponentModel.DataAnnotations;

namespace ProyectoSistemaUsuarios.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Correo requerido")]
        [EmailAddress(ErrorMessage = "Formato de correo inválido")]
       
        public string Correo {  get; set; }

        [Required(ErrorMessage = "Contraseña es requerida")]
        [Display(Name = "Contraseña")]
        public string Contrasena { get; set; }

    }
}
