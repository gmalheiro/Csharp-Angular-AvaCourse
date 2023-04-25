using System;
using System.Collections.Generic;

namespace ProjetoDados.Entidades;

public partial class Turma
{
    public int Id { get; set; }

    public string NomeTurma { get; set; } = null!;

    public virtual ICollection<Aluno> Alunos { get; set; } = new List<Aluno>();
}
