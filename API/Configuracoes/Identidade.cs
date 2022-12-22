using Domain.Entities;
using Infra.Configuration;
using Microsoft.AspNetCore.Identity;

namespace API.Configuracoes
{
    public static class Identidade
    {
        public static void AddIdentidadeUsuario(this IServiceCollection services)
        {
            services.AddDefaultIdentity<Usuario>(x =>
            {
                x.SignIn.RequireConfirmedAccount = true;
                x.Tokens.PasswordResetTokenProvider = TokenOptions.DefaultEmailProvider;
                x.Tokens.EmailConfirmationTokenProvider = TokenOptions.DefaultEmailProvider;
                x.Tokens.AuthenticatorTokenProvider = TokenOptions.DefaultProvider;
            })
            .AddEntityFrameworkStores<ContextBase>()
            .AddDefaultTokenProviders();
        }

    }
}
