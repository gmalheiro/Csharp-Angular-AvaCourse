﻿using CursoAvanadeDotnetAngular.Contexto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CursoAvanadeDotnetAngular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TurmaController : ControllerBase
    {

        private readonly CursoContexto _context;

        public TurmaController(CursoContexto context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("/ListarTodos")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<DTO.Turma>))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ListarTodos()
        {
            try
            {
                List<Entidade.Turma> lsTurmaEntidade = _context.Turmas.ToList();

                if (lsTurmaEntidade == null || lsTurmaEntidade.Count == 0)
                {
                    return NoContent();
                }

                List<DTO.Turma> lsTurmaDto = new List<DTO.Turma>();

                lsTurmaEntidade.ForEach(s =>
                    lsTurmaDto.Add(
                    new DTO.Turma()
                    {
                        Id = s.Id,
                        NomeTurma = s.NomeTurma
                    })
                );

                return Ok(lsTurmaDto);
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        [HttpGet]
        [Route("/PorId")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DTO.Turma))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult PorId(int Id)
        {
            try
            {
                // Entidade.Turma turmaEntidade = _context.Turmas
                // .Where(w => w.Id == Id)
                // ?.First()
                // ?? null;
                // 
                // Entidade.Turma turmaEntidade = _context.Turmas
                // .Where(w => w.Id == Id)
                // ?.First()
                // ?? new Entidade.Turma turmaEntidadeNull();
                //Maneira para caso não encontre o registro, retornar null(SEM UTILIZAR O FIRST OR DEFAULT)
                //Entidade.Turma turmaEntidade = _context.Turmas.Where(w => w.Id == Id).FirstOrDefault(); // MANEIRA PARA ENCONTRAR UTILIZANDO O WHERE
                Entidade.Turma turmaEntidade = _context.Turmas.FirstOrDefault(w => w.Id == Id);

                if (turmaEntidade == null)
                {
                    return NoContent();
                }

                DTO.Turma turmaDto = new DTO.Turma()
                {
                    Id = turmaEntidade.Id,
                    NomeTurma = turmaEntidade.NomeTurma.ToString()
                };


                return Ok(turmaDto);
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
    }
}