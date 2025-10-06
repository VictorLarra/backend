
using Microsoft.EntityFrameworkCore;
using SIGU.API.Models;

namespace SIGU.API.Data
{
    public class SiguContext : DbContext
    {
        public SiguContext(DbContextOptions<SiguContext> options)
            : base(options)
        {
        }

        // DbSets -> Tablas en la BD
        public DbSet<Usuario> usuarios { get; set; }
        public DbSet<programa> programas { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // 👇 Forzamos nombres de tablas en minúscula
            modelBuilder.Entity<Usuario>().ToTable("usuarios");
            modelBuilder.Entity<programa>().ToTable("programas");
            modelBuilder.Entity<programa>().HasData(

        new programa { programaid = 1, nombre = "Ingeniería de Sistemas" },
        new programa { programaid = 2, nombre = "Ingeniería Civil" },
        new programa { programaid = 3, nombre = "Ingeniería Mecatrónica" },
        new programa { programaid = 4, nombre = "Arquitectura" },
        new programa { programaid = 5, nombre = "Ingeniería de Telecomunicacioes" }
    );
}

            // ⚡ Relaciones

            // Usuario ↔ Matricula (1:N)

        }
    }

        
        
