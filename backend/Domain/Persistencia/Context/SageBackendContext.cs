using Domain.Persistencia.Dominio;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Domain.Persistencia.Context
{
    public class SageBackendContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        public SageBackendContext(DbContextOptions<SageBackendContext> options) : base(options) { }

        public SageBackendContext() { }

        #region DataSet

        public DbSet<PeopleModel> Peoples { get; set; }
        public DbSet<AddressModel> Addresses { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            modelBuilder.HasDefaultSchema("SageBackend");
            
        }
    }
}