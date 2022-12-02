using Domain.Entities;
using Domain.Interfaces;
using Infra.Configuration;
using Infra.Repository.Generics;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repository.Repository
{
    public class RepositoryMessage : RepositoryGenerics<Message>, IMessage
    {
        private readonly DbContextOptions<ContextBase> _optionsBuilder;

        public RepositoryMessage()
        {
            _optionsBuilder = new DbContextOptions<ContextBase>();
        }
    }
}
