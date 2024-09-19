using Dapper;
using ProyectoSistemaUsuarios.Models;
using System.Data.SqlClient;

namespace ProyectoSistemaUsuarios.Servicios
{

    public interface IRepositorioUsuarios
    {
        Task<int> CrearUsuario(Usuario usuario);
    }

    public class RepositorioUsuarios: IRepositorioUsuarios
    {

        //CADENA DE CONEXION
        private readonly string cadenaConexion;
        public RepositorioUsuarios(IConfiguration configuration)
        {
            cadenaConexion = configuration.GetConnectionString("DefaultConnection");
        }


        //CREA EL USUARIO Y OBTIENE SU ID
        public async Task<int> CrearUsuario(Usuario usuario)
        {
            using var conexion = new SqlConnection(cadenaConexion);

            //INSERTA EN LA BASE DE DATOS
            var id = await conexion.QuerySingleAsync<int>("");
        }
    }
}
