using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CursoAvanadeDotnetAngular.Entidade;

public partial class Aluno
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public string? Documento { get; set; }

    public DateOnly? Nascimento { get; set; }

    public int? IdTurma { get; set; }
    [NotMapped]
    public virtual Turma? IdTurmaNavigation { get; set; }
}
