using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CursoAvanadeDotnetAngular.Entidade;

public partial class Turma
{
    public int Id { get; set; }

    public string NomeTurma { get; set; } = null!;
    [NotMapped]
    public virtual ICollection<Aluno> Alunos { get; set; } = new List<Aluno>();
}
