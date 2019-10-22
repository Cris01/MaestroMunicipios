using MaestroMunicipios.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MaestroMunicipios.Infraestructure
{
    public class MaestroMunicipioContext : DbContext
    {
        public MaestroMunicipioContext(DbContextOptions<MaestroMunicipioContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (modelBuilder == null)
            {
                return;
            }
            modelBuilder.Entity<Department>();
            modelBuilder.Entity<City>();

            modelBuilder.ShadowProperties();

            base.OnModelCreating(modelBuilder);
        }
    }
}
