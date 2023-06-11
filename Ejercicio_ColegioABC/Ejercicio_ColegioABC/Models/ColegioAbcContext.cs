using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Ejercicio_ColegioABC.Models;

public partial class ColegioAbcContext : DbContext
{
    public ColegioAbcContext()
    {
    }

    public ColegioAbcContext(DbContextOptions<ColegioAbcContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Curso> Cursos { get; set; }

    public virtual DbSet<Estudiante> Estudiantes { get; set; }

    public virtual DbSet<Materia> Materias { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=192.168.0.20\\\\\\\\SERVER\\\\\\\\SQLEXPRESS,1433;Database=ColegioABC; User Id=bduserX; Password=admin1234; TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Curso>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Cursos__3214EC27D44106EA");

            entity.HasIndex(e => e.Idestudiante, "UQ__Cursos__908672BAF69F22F9").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Idestudiante).HasColumnName("IDEstudiante");
            entity.Property(e => e.Nombre).HasMaxLength(255);

            entity.HasOne(d => d.IdestudianteNavigation).WithOne(p => p.Curso)
                .HasForeignKey<Curso>(d => d.Idestudiante)
                .HasConstraintName("FK__Cursos__IDEstudi__276EDEB3");

            entity.HasMany(d => d.Idmateria).WithMany(p => p.Idcursos)
                .UsingEntity<Dictionary<string, object>>(
                    "CursoMaterium",
                    r => r.HasOne<Materia>().WithMany()
                        .HasForeignKey("Idmateria")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Curso_Mat__IDMat__30F848ED"),
                    l => l.HasOne<Curso>().WithMany()
                        .HasForeignKey("Idcurso")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Curso_Mat__IDCur__300424B4"),
                    j =>
                    {
                        j.HasKey("Idcurso", "Idmateria").HasName("PK__Curso_Ma__C98913E2294EB32A");
                        j.ToTable("Curso_Materia");
                    });
        });

        modelBuilder.Entity<Estudiante>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Estudian__3214EC27ECA1DA37");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Apellido).HasMaxLength(255);
            entity.Property(e => e.Nombre).HasMaxLength(255);
        });

        modelBuilder.Entity<Materia>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Materias__3214EC275F57ADCA");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Nombre).HasMaxLength(255);

            entity.HasMany(d => d.Idestudiantes).WithMany(p => p.Idmateria)
                .UsingEntity<Dictionary<string, object>>(
                    "EstudianteMaterium",
                    r => r.HasOne<Estudiante>().WithMany()
                        .HasForeignKey("Idestudiante")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Estudiant__IDEst__2D27B809"),
                    l => l.HasOne<Materia>().WithMany()
                        .HasForeignKey("Idmateria")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Estudiant__IDMat__2C3393D0"),
                    j =>
                    {
                        j.HasKey("Idmateria", "Idestudiante").HasName("PK__Estudian__72E4E35F2485D6F3");
                        j.ToTable("Estudiante_Materia");
                    });
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
