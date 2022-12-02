using Domain.DTOs.Input;
using Domain.DTOs.Output;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace Domain.Interfaces
{
    public interface IUsuarioService
    {
        Task<SignInResult> AutenticarUsuarioAsync(UsuarioLogin login);
        Task<Usuario?> BuscarUsuarioPorEmailAsync(string email);
        TokenOutput GerarToken(Usuario usuario);
        Task<IdentityResult> InserirUsuarioAsync(UsuarioLogin login);
    }
}
