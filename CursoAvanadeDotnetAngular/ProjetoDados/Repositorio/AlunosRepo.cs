using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ProjetoDados.Contexto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoDados.Repositorio
{
    public class AlunosRepo
    {

        private readonly IConfiguration _configuration;
        private readonly CursoContexto _context;

        public AlunosRepo(IConfiguration configuration, CursoContexto context)
        {
            _configuration = configuration;
            _context = context;
        }

        public List<DTO.Aluno>ListarTodos()
        {
            return (from alunos in _context.Alunos
             select new DTO.Aluno()
             {
                 Id = alunos.Id,
                 Nome = alunos.Nome,
                 Documento = alunos.Documento,
                 IdTurma = alunos.IdTurma,
                 Nascimento = alunos.Nascimento,
             }).ToList();
        }
    }
}
