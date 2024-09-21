﻿using Microsoft.AspNetCore.Identity;
using ProyectoSistemaUsuarios.Models;

namespace ProyectoSistemaUsuarios.Servicios
{
    public class UsuarioStore : IUserStore<Usuario>, IUserEmailStore<Usuario>,
        IUserPasswordStore<Usuario>
    {
        //PARA UTILIZAR EL REPOSITORIO DE USUARIOS
        private readonly IRepositorioUsuarios repositorioUsuarios;

        public UsuarioStore(IRepositorioUsuarios repositorioUsuarios)
        {
            this.repositorioUsuarios = repositorioUsuarios;
        }


        public async Task<IdentityResult> CreateAsync(Usuario user, CancellationToken cancellationToken)
        {
            //SE UTILIZA EL SERVICIO DE USUARIOS PARA CREAR EL USUARIO
            user.id = await repositorioUsuarios.CrearUsuario(user);
            return IdentityResult.Success;
        }

        public Task<IdentityResult> DeleteAsync(Usuario user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {

        }

        public async Task<Usuario?> FindByEmailAsync(string normalizedEmail, CancellationToken cancellationToken)
        {
            //BUSCA EL USUARIO POR EMAIL
            return await repositorioUsuarios.BuscarUsuarioPorEmail(normalizedEmail);
        }

        public Task<Usuario?> FindByIdAsync(string userId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<Usuario?> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
        {
            //BUSCA EL USUARIO POR EMAIL
            return await repositorioUsuarios.BuscarUsuarioPorEmail(normalizedUserName);
        }

        public Task<string?> GetEmailAsync(Usuario user, CancellationToken cancellationToken)
        {
            //RETORNA EL EMAIL DEL USUARIO
            return Task.FromResult(user.Correo);
        }

        public Task<bool> GetEmailConfirmedAsync(Usuario user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<string?> GetNormalizedEmailAsync(Usuario user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<string?> GetNormalizedUserNameAsync(Usuario user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<string?> GetPasswordHashAsync(Usuario user, CancellationToken cancellationToken)
        {
            //RETORNA LA CONTRASEÑA DEL USUARIO
            return Task.FromResult(user.Contrasena);
        }

        public Task<string> GetUserIdAsync(Usuario user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.id.ToString());
        }

        public Task<string?> GetUserNameAsync(Usuario user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.Correo);
        }

        public Task<bool> HasPasswordAsync(Usuario user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetEmailAsync(Usuario user, string? email, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetEmailConfirmedAsync(Usuario user, bool confirmed, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetNormalizedEmailAsync(Usuario user, string? normalizedEmail, CancellationToken cancellationToken)
        {
            user.Correo = normalizedEmail;

            return Task.CompletedTask;
        }

        public Task SetNormalizedUserNameAsync(Usuario user, string? normalizedName, CancellationToken cancellationToken)
        {
            user.Correo = normalizedName;

            return Task.CompletedTask;
        }

        public Task SetPasswordHashAsync(Usuario user, string? passwordHash, CancellationToken cancellationToken)
        {
            //CONVIERTE LA CONTRASEÑA DEL USUARIO EN UN HASH
            user.Contrasena = passwordHash;
            return Task.CompletedTask;
        }

        public Task SetUserNameAsync(Usuario user, string? userName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<IdentityResult> UpdateAsync(Usuario user, CancellationToken cancellationToken)
        {
            //ACTUALIZA LA CONTRASEÑA DEL USUARIO
            await repositorioUsuarios.Actualizar(user);
            return IdentityResult.Success;
        }
    }
}
