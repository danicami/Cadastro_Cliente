using Microsoft.EntityFrameworkCore;
using Webapi_Cliente.Domain.Entities;
using Webapi_Cliente.Infra.Data.Mapping;

namespace Webapi_Cliente.Infra.Data.Context
{
    public class ApplicationContext :DbContext
    {

        public DbSet<Cliente> Clientes { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //        optionsBuilder.UseInMemoryDatabase (@"Server=(localdb)\mssqllocaldb;Database=Cliente;Trusted_Connection=True;ConnectRetryCount=0");

        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Cliente>(new ClienteMap().Configure);
        }

    }
}
