using Data.Mapping;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Context
{
    public class DatabaseContext : DbContext
    {
        public DbSet<UsuarioEntity> Users { get; set; }
        
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base (options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UsuarioEntity>(new UserMapping().Configure);
        }
    }
}