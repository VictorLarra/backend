// using Microsoft.EntityFrameworkCore;
// using SIGU.API.Models;

// namespace SIGU.API.Data
// {
//     public class SiguContext : DbContext
//     {
//         public SiguContext(DbContextOptions<SiguContext> options) : base(options) { }

//         public DbSet<Usuario> usuarios { get; set; }
//         public DbSet<Programa> Programas { get; set; }
//         public DbSet<Materia> Materias { get; set; }
//         public DbSet<Grupo> Grupos { get; set; }
//         public DbSet<Matricula> Matriculas { get; set; }
//         public DbSet<Nota> Notas { get; set; }

//         protected override void OnModelCreating(ModelBuilder modelBuilder)
//         {
//             // Usuario → Programa
//             modelBuilder.Entity<Usuario>()
//                 .HasOne(u => u.Programa)
//                 .WithMany(p => p.Usuarios)
//                 .HasForeignKey(u => u.ProgramaId);

//             // Grupo → Materia
//             modelBuilder.Entity<Grupo>()
//                 .HasOne(g => g.Materia)
//                 .WithMany(m => m.Grupos)
//                 .HasForeignKey(g => g.MateriaId);

//             // Matrícula → Usuario y Grupo
//             modelBuilder.Entity<Matricula>()
//                 .HasOne(m => m.Usuario)
//                 .WithMany(u => u.Matriculas)
//                 .HasForeignKey(m => m.UsuarioId);

//             modelBuilder.Entity<Matricula>()
//                 .HasOne(m => m.Grupo)
//                 .WithMany(g => g.Matriculas)
//                 .HasForeignKey(m => m.GrupoId);

//             // Nota → Matrícula
//             modelBuilder.Entity<Nota>()
//                 .HasOne(n => n.Matricula)
//                 .WithMany(m => m.Notas)
//                 .HasForeignKey(n => n.MatriculaId);
//         }
//     }
// }
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


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // 👇 Forzamos nombres de tablas en minúscula
            modelBuilder.Entity<Usuario>().ToTable("usuarios");

            // ⚡ Relaciones

            // Usuario ↔ Matricula (1:N)

        }
    }
}
        
        
