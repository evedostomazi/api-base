using Domain.Token;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace API.Configuracoes
{
    public static class JwtConfiguracoes
    {
        public static void AddJwtConfiguracoes(this IServiceCollection services)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
      .AddJwtBearer(option =>
      {
          option.RequireHttpsMetadata = true;
          option.SaveToken = true;

          option.TokenValidationParameters = new TokenValidationParameters
          {
              ValidateIssuer = true,
              ValidateAudience = true,
              ValidateLifetime = true,
              ValidateIssuerSigningKey = true,

              ValidIssuer = "TMZ.Securiry.Bearer",
              ValidAudience = "TMZ.Securiry.Bearer",
              IssuerSigningKey = JwtSecurityKey.Create("Secret_Key-5OwgD42WT3h5k")
          };

          option.Events = new JwtBearerEvents
          {
              OnAuthenticationFailed = context =>
              {
                  Console.WriteLine("OnAuthenticationFailed: " + context.Exception.Message);
                  return Task.CompletedTask;
              },
              OnTokenValidated = context =>
              {
                  Console.WriteLine("OnTokenValidated: " + context.SecurityToken);
                  return Task.CompletedTask;
              }
          };
      });
        }
    }
}
