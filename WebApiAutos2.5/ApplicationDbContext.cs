using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApiAutos2._5.Entidades;

namespace WebApiAutos2._5
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            base.OnModelCreating(modelbuilder);

            modelbuilder.Entity<AutoMarca>()
                .HasKey(au => new { au.AutoId, au.MarcaId });
            
        }
        public DbSet<Auto> Autos { get; set; }
        public DbSet<Marca> Marcas {get; set; }
        public DbSet<Grupo> Grupos { get; set; }
        public DbSet<AutoMarca> AutoMarcas { get; set; }
    }
}