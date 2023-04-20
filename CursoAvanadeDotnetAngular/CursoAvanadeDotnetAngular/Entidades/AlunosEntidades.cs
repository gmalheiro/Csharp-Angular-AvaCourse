using System.Text;

namespace CursoAvanadeDotnetAngular.Entidades
{
    public class AlunosEntidades
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Documento { get; set; }
        public int? IdTurma { get; set; }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("Nome:");
            stringBuilder.AppendLine(Nome);
            stringBuilder.Append("Documento:");
            stringBuilder.AppendLine(Documento);
            stringBuilder.Append("Está no curso de:");
            //string curso = 
            stringBuilder.AppendLine(IdTurma == 1 ? "C#" : "Angular");
            return stringBuilder.ToString();
        }

    }
}
