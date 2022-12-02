using Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infra.Configuration
{
    public class ContextBase : IdentityDbContext<Usuario>
    {
        public ContextBase(DbContextOptions<ContextBase> options) : base(options)
        { }

        public DbSet<Message>? Message { get; set; }
        public DbSet<Usuario>? ApplicationUser { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ObterStringConexao);
                base.OnConfiguring(optionsBuilder);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Usuario>().ToTable("AspNetUsers").HasKey(t => t.Id);
            base.OnModelCreating(builder);
        }


        const string ObterStringConexao = "Data Source=NBDESADM351\\SQLEXPRESS;Initial Catalog=API_DDD_2022;Integrated Security=False;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False;trusted_connection=true";

    }
}

