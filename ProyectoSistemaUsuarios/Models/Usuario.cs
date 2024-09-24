using System.ComponentModel.DataAnnotations;

namespace ProyectoSistemaUsuarios.Models
{
    public class Usuario
    {

        public int id { get; set; }


        public int Cedula { get; set; }

        public string Correo { get; set; }

        [Required]
        public string Nombre { get; set; }

        public string Apellidos { get; set; }

        
        public string Contrasena { get; set; }

        public TipoRol idRol {  get; set; }



    }
}
