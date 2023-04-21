namespace CursoAvanadeDotnetAngular.DTO
{
    public class Aluno
    {
        public int Id { get; set; }

        public string? Nome { get; set; } = null!;

        public string? Documento { get; set; }

        public DateOnly? Nascimento { get; set; }

        public int? IdTurma { get; set; }
    }
}
