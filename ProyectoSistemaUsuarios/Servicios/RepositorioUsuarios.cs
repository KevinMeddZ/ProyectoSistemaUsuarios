using Dapper;
using ProyectoSistemaUsuarios.Models;
using System.Data.SqlClient;

namespace ProyectoSistemaUsuarios.Servicios
{

    public interface IRepositorioUsuarios
    {
        Task Actualizar(Usuario usuario);
        Task<Usuario> BuscarUsuarioPorEmail(string Correo);
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

            //INSERTA EN LA BASE DE DATOS Y DEVUELVE EL ID DEL USUARIO
            var id = await conexion.QuerySingleAsync<int>(@"
            INSERT INTO tblUsuario (Cedula, Correo, Nombre, Apellidos, Contrasena, idRol)
	        VALUES (@Cedula, @Correo, @Nombre, @Apellidos, @Contrasena, @idRol);
	        SELECT SCOPE_IDENTITY()", usuario);

            return id;
        }


        //METODO PARA BUSCAR EL USUARIO POR EMAIL
        public async Task<Usuario> BuscarUsuarioPorEmail(string Correo)
        {
            using var conexion = new SqlConnection(cadenaConexion);

            //BUSCA EL USUARIO POR CORREO EN LA BASE DE DATOS MEDIANTE UNA CONSULTA
            return await conexion.QuerySingleOrDefaultAsync<Usuario>(@"
                   SELECT * FROM tblUsuario WHERE Correo = @Correo", new { Correo });

        }

        //METODO PARA ACTUALIZAR LA CONTRASEÑA DEL USUARIO
        public async Task Actualizar(Usuario usuario)
        {
            using var conexion = new SqlConnection(cadenaConexion);

            await conexion.ExecuteAsync(@"UPDATE tblUsuario SET Contrasena = @Contrasena WHERE id = @id", usuario);
        }
    }
}
