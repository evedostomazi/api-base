using Domain.Interfaces;
using Domain.Interfaces.Generics;
using Domain.Interfaces.Services;
using Domain.Services;
using Infra.Configuration;
using Infra.Repository.Generics;
using Infra.Repository.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Service.AutoMapper;
using Service.Services;

namespace Infra.CrossCutting.IoC
{
    public static class NativeInjector
    {
        public static void AddRegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(typeof(DtoToDomain), typeof(DomainToDto));
            services.AddSingleton(typeof(IGeneric<>), typeof(RepositoryGenerics<>));
            services.AddSingleton<IMessage, RepositoryMessage>();
            services.AddSingleton<IServiceMessage, ServiceMessage>();
            services.AddTransient<IUsuarioService, UsuarioService>();

            services.AddDbContext<ContextBase>(options =>
                options.UseNpgsql(
                    configuration.GetConnectionString("DefaultConnectionPG")));
        }
    }
}