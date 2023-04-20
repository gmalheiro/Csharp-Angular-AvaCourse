using System;
using System.Collections.Generic;
using CursoAvanadeDotnetAngular.Entidade;
using Microsoft.EntityFrameworkCore;

namespace CursoAvanadeDotnetAngular.Contexto;

public partial class CursoContexto : DbContext
{
    public CursoContexto()
    {
    }

    public CursoContexto(DbContextOptions<CursoContexto> options)
        : base(options)
    {
    }

    public virtual DbSet<Aluno> Alunos { get; set; }

    public virtual DbSet<Turma> Turmas { get; set; }

    public virtual DbSet<VwAlunosComNascimento> VwAlunosComNascimentos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\localhost;Initial Catalog=Cursos;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;MultiSubnetFailover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Aluno>(entity =>
        {
            entity.Property(e => e.Documento).IsUnicode(false);
            entity.Property(e => e.IdTurma).HasColumnName("idTurma");
            entity.Property(e => e.Nome)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Turma>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Turmas__3214EC0794443425");

            entity.Property(e => e.NomeTurma)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<VwAlunosComNascimento>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_AlunosComNascimento");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Nome)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
