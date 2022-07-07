using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Examen.Models
{
    public partial class BDExamenContext : DbContext
    {
        public BDExamenContext()
        {
        }

        public BDExamenContext(DbContextOptions<BDExamenContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Alumno> Alumno { get; set; }
        public virtual DbSet<Curso> Curso { get; set; }
        public virtual DbSet<Nota> Nota { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=NBPE00062 ; Database=BDExamen; user id= sa; password = sql;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Alumno>(entity =>
            {
                entity.HasKey(e => e.IdAlumno)
                    .HasName("PK__Alumno__43FBBAC78EADE7A3");

                entity.Property(e => e.IdAlumno).HasColumnName("idAlumno");

                entity.Property(e => e.ApellidoMaterno)
                    .IsRequired()
                    .HasColumnName("apellidoMaterno")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ApellidoPaterno)
                    .IsRequired()
                    .HasColumnName("apellidoPaterno")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FechaNacimiento).HasColumnType("datetime");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Sexo)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Curso>(entity =>
            {
                entity.HasKey(e => e.IdCurso)
                    .HasName("PK__Curso__8551ED0542673895");

                entity.Property(e => e.IdCurso).HasColumnName("idCurso");

                entity.Property(e => e.Descripción)
                    .IsRequired()
                    .HasColumnName("descripción")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Obligatoriedad)
                    .IsRequired()
                    .HasColumnName("obligatoriedad")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Nota>(entity =>
            {
                entity.HasKey(e => e.IdNota)
                    .HasName("PK__Nota__AD5F462E9880A480");

                entity.Property(e => e.IdNota).HasColumnName("idNota");
                      

                entity.Property(e => e.IdAlumno).HasColumnName("idAlumno");

                entity.Property(e => e.IdCurso).HasColumnName("idCurso");

                entity.Property(e => e.PracticaA)
                    .HasColumnName("practicaA")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.PracticaB)
                    .HasColumnName("practicaB")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.PracticaC)
                    .HasColumnName("practicaC")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.Promedio)
                    .HasColumnName("promedio")
                    .HasColumnType("decimal(4, 2)");

              entity.HasOne(d => d.IdAlumnoNavigation)
                    .WithMany(p => p.Nota)
                    .HasForeignKey(d => d.IdAlumno)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Nota__idAlumno__286302EC");

                entity.HasOne(d => d.IdCursoNavigation)
                    .WithMany(p => p.Nota)
                    .HasForeignKey(d => d.IdCurso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Nota__idCurso__29572725"); 
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
