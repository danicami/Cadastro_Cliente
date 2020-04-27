using System;
using Microsoft.EntityFrameworkCore;

namespace Webapi_Cliente.Models
{
    public class ApplicationContext :DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Cliente>().HasKey(t => t.ID);

        }

        public DbSet<Cliente> Clientes { get; set; }


    }
}
