using Domain.DTOs.Input;
using Domain.DTOs.Output;
using Domain.Entities;
using Domain.Enum;
using Domain.Interfaces;
using Domain.Token;
using Microsoft.AspNetCore.Identity;

namespace Service.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly SignInManager<Usuario> _signInManager;
        private readonly UserManager<Usuario> _userManager;

        public UsuarioService(SignInManager<Usuario> signInManager, UserManager<Usuario> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public async Task<SignInResult> AutenticarUsuarioAsync(UsuarioLogin login)
        {
            return await _signInManager.PasswordSignInAsync(login.Email, login.Senha, false, lockoutOnFailure: false);
        }

        public async Task<Usuario?> BuscarUsuarioPorEmailAsync(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }

        public TokenOutput GerarToken(Usuario usuario)
        {
            var token = new TokenJwtBuilder()
                        .AddSecurityKey(JwtSecurityKey.Create("Secret_Key-5OwgD42WT3h5k"))
                        .AddSubject("BigFood - Restaurante Agil")
                        .AddIssuer("BigFood.Securiry.Bearer")
                        .AddAudience("BigFood.Securiry.Bearer")
                        .AddClaim("idUsuario", usuario.Id)
                        .AddExpiry(5)
                        .Builder();
            return new TokenOutput { token_acesso = token.value, perfil_usuario = usuario.PermissaoUsuario };
        }

        public async Task<IdentityResult> InserirUsuarioAsync(UsuarioLogin login)
        {
            var usuario = new Usuario
            {
                UserName = login.Email,
                Email = login.Email,
                PermissaoUsuario = PerfilUsuario.Client
            };
            return await _userManager.CreateAsync(usuario, login.Senha);
        }
    }
}
