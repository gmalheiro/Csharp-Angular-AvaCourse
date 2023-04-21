using CursoAvanadeDotnetAngular.Contexto;
using CursoAvanadeDotnetAngular.Entidade;
using CursoAvanadeDotnetAngular.Entidades;
using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace CursoAvanadeDotnetAngular.Controllers
{
    [Route("api/Alunos")]
    [ApiController]
    public class AlunosController : ControllerBase
    {

        private readonly IConfiguration _configuration;
        private readonly CursoContexto _context;

        public AlunosController(IConfiguration configuration, CursoContexto context)
        {
            _configuration = configuration;
            _context = context;
        }

        [HttpGet]
        [Route("/Buscar/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Entidades.AlunosEntidades))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(String))]
        public IActionResult Get(int id)
        {
            Entidades.AlunosEntidades alunoEntidade =
                new Entidades.AlunosEntidades(); // Cria a lista que será retornada

            string conexaoComOBanco = _configuration.GetConnectionString("Sql"); //Pega a string de conexão com o banco

            using (SqlConnection conexao = new SqlConnection(conexaoComOBanco)) //Cria a conexão com o banco
            {
                conexao.Open();

                string comando = $"SELECT * FROM ALUNOS WHERE ID = {id}"; //Cria o comando SQL que será executado

                using (SqlCommand sqlCommand = new SqlCommand(comando, conexao))  //Cria o objeto que irá executar o comando SQL
                {
                    SqlDataReader leitor = sqlCommand.ExecuteReader(); // Executa o comando SQL - para SELECT é o ExecuteReader // Vai listando cada item do leitor | Para INSERT, UPDATE, DELETE é o ExecuteNonQuery | Para retornar apenas um valor é o ExecuteScalar | Para retornar um objeto é o ExecuteReader | E vai retornar um data reader


                    if (!leitor.HasRows)
                        return NotFound("Não encontrado o id pesquisado");

                    while (leitor.Read())
                    {
                        alunoEntidade = new Entidades.AlunosEntidades()
                        {
                            Id = Convert.ToInt32(leitor["Id"]),
                            //Nome = leitor["Nome"]?.ToString() ?? "",
                            Nome = Helper.TratarNulo<string>(leitor["Nome"]),
                            //Documento = leitor["Documento"]?.ToString() ?? "",
                            Documento = Helper.TratarNulo<string>(leitor["Documento"]),
                            //IdTurma = (DBNull.Value.Equals(leitor["IdTurma"]) ? (int?)null : Convert.ToInt32(leitor["IdTurma"])) 
                            IdTurma = Helper.TratarNulo<int?>(leitor["IdTurma"])
                        };
                    }
                }
            }
            return Ok(alunoEntidade);
        }

        [HttpGet]
        [Route("/BuscarAdo")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Entidades.AlunosEntidades>))]
        public IActionResult BuscarAdo()
        {
            List<Entidades.AlunosEntidades> lista =
                new List<Entidades.AlunosEntidades>(); // Cria a lista que será retornada

            string conexaoComOBanco = _configuration.GetConnectionString("Sql"); //Pega a string de conexão com o banco

            using (SqlConnection conexao = new SqlConnection(conexaoComOBanco)) //Cria a conexão com o banco
            {
                conexao.Open();

                string comando = "SELECT * FROM ALUNOS"; //Cria o comando SQL que será executado

                using (SqlCommand sqlCommand = new SqlCommand(comando, conexao))  //Cria o objeto que irá executar o comando SQL
                {
                    SqlDataReader leitor = sqlCommand.ExecuteReader(); // Executa o comando SQL - para SELECT é o ExecuteReader // Vai listando cada item do leitor | Para INSERT, UPDATE, DELETE é o ExecuteNonQuery | Para retornar apenas um valor é o ExecuteScalar | Para retornar um objeto é o ExecuteReader | E vai retornar um data reader

                    while (leitor.Read())
                    {
                        lista.Add(new Entidades.AlunosEntidades()
                        {
                            Id = Convert.ToInt32(leitor["Id"]),
                            //Nome = leitor["Nome"]?.ToString() ?? "",
                            Nome = Helper.TratarNulo<string>(leitor["Nome"]),
                            //Documento = leitor["Documento"]?.ToString() ?? "",
                            Documento = Helper.TratarNulo<string>(leitor["Documento"]),
                            //IdTurma = (DBNull.Value.Equals(leitor["IdTurma"]) ? (int?)null : Convert.ToInt32(leitor["IdTurma"])) 
                            IdTurma = Helper.TratarNulo<int?>(leitor["IdTurma"])
                        });
                    }
                }
            }
            return Ok(lista);
        }

        [HttpGet]
        [Route("/BuscarValorComoReferencia")]
        public IActionResult BuscarValorComoReferencia()
        {
            int numero1 = 1;
            int numero2 = 3;

            Helper.SomarReferencia(ref numero1, numero2);

            return Ok(numero1);
        }

        [HttpGet]
        [Route("/BuscarReferencia")]
        public IActionResult BuscarReferencia()
        {
            MensagemRetornoNaoAutorizado mensagem = new MensagemRetornoNaoAutorizado()
            {
                Mensagem = "Valor Preenchido"
            };

            Helper.OutroExemplo(mensagem);

            return Ok(mensagem);
        }

        [HttpGet]
        [Route("/BuscarDapper")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Entidades.AlunosEntidades))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(String))]
        public IActionResult BuscarDapper()
        {
            string conexaoComOBanco = _configuration.GetConnectionString("Sql"); //Pega a string de conexão com o banco

            SqlConnection conexao = new SqlConnection(conexaoComOBanco); //Cria a conexão com o banco
            string comando = "SELECT * FROM ALUNOS"; //Cria o comando SQL que será executado
            List<Entidades.AlunosEntidades> lista = conexao.Query<Entidades.AlunosEntidades>(comando).ToList(); // Cria a lista que será retornada

            return Ok(lista);
        }


        [HttpGet]
        [Route("/BuscarDapper/{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Entidades.AlunosEntidades))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(String))]
        public IActionResult BuscarDapper(int Id)
        {
            string conexaoComOBanco = _configuration.GetConnectionString("Sql"); //Pega a string de conexão com o banco

            var parametrosConsulta = new DynamicParameters();
            parametrosConsulta.Add("@Id", Id);

            SqlConnection conexao = new SqlConnection(conexaoComOBanco); //Cria a conexão com o banco
            string comando = "SELECT * FROM ALUNOS WHERE Id = @Id"; //Cria o comando SQL que será executado
            Entidades.AlunosEntidades aluno = conexao
                                            .Query<Entidades.AlunosEntidades>(comando, parametrosConsulta)
                                            ?.FirstOrDefault()
                                            ?? new Entidades.AlunosEntidades(); // Cria o objeto que será retornada

            return Ok(aluno);
        }

        [HttpPost]
        [Route("/Criar")]
        public async Task<ActionResult> Post(Entidades.AlunosEntidades alunosEntidades)
        {
            try
            {
                SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("Sql"));
                int linhasAfetadas = connection.Execute(
                    "INSERT INTO [dbo].[Alunos]" +
                    "([Nome],[Documento],[IdTurma],[Nascimento])" +
                    "VALUES (@Nome,@Documento,@IdTurma,@Nascimento)", alunosEntidades);

                //int IdCadastrado = connection.Query<int>("SELECT @@Identity").FirstOrDefault();

                return Ok($"Linhas afetadas no banco de dados:{linhasAfetadas}\n" +
                          $"{alunosEntidades.ToString()}");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("/[controller]/Atualizar")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Entidades.AlunosEntidades))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Update(DTO.Turma turmaEntrada)
        {
            try
            {

                Entidade.Turma turmaEntidade = new Entidade.Turma()
                {
                    NomeTurma = turmaEntrada.NomeTurma,
                    Id = turmaEntrada.Id,
                };


                // LIMPA QUALQUER ALTERAÇÃO EM MEMÓRIA QUE NÃO FOI SALVA
                _context.ChangeTracker.Clear();
                // INSERT 
                _context.Turmas.Update(turmaEntidade);
                // COMMIT NA BASE DE DADOS
                _context.SaveChanges();

                return Ok(turmaEntrada);
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        [HttpDelete]
        [Route("/ApagarApenasUmAluno")]
        public IActionResult Delete(int id)
        {
            return Ok();
            //return NoContent();
            //return NotFound();
        }

        [HttpDelete]
        [Route("/ApagarTodosOsAlunos")]
        public IActionResult Delete()
        {
            try
            {
                SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("Sql"));
                int linhasAfetadas = connection.Execute("TRUNCATE TABLE ALUNOS");

                return Ok(linhasAfetadas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        //[HttpPatch]
        //[Route("/AtualizarAlunoDataNascimentoDapper")]
        //public IActionResult Patch(Aluno alunoParametro)
        //{
        //    string conexaoComOBanco = _configuration.GetConnectionString("Sql"); //Pega a string de conexão com o banco

        //    var parametros = new DynamicParameters();
        //    parametros.Add("@Id", alunoParametro.Id);
        //    parametros.Add("@Nascimento", alunoParametro.Nascimento);

        //    using (SqlConnection conexao = new SqlConnection(conexaoComOBanco)) //Cria a conexão com o banco
        //    {
        //        // Validate if the record exists before updating
        //        var aluno = conexao.QueryFirstOrDefault<AlunosEntidades>("SELECT * FROM Alunos WHERE Id = @Id", parametros);
        //        if (aluno == null)
        //        {
        //            return NotFound(); // Return 404 Not Found if the record doesn't exist
        //        }

        //        string comando = "UPDATE Alunos SET Nascimento = @Nascimento  WHERE Id = @Id"; //Cria o comando SQL que será executado
        //        conexao.Execute(comando, parametros); // Executa o comando SQL

        //        aluno = conexao.QueryFirstOrDefault<AlunosEntidades>("SELECT * FROM Alunos WHERE Id = @Id", parametros); //Busca o registro atualizado no banco

        //        return Ok(aluno);
        //    }
        //}



        //[HttpDelete]
        //[Route("/ApagarApenasOsInativos")]
        //public IActionResult Delete()
        //{
        //    return Ok();
        //}


        [HttpGet]
        [Route("/ListarEF")]
        public IActionResult ListarEF()
        {   
            return Ok(_context.Alunos.ToList());
        }

    }

    public class Helper
    {
        public static void Somar(int num, int num2)
        {
            num += num2;
        }

        public static void SomarReferencia(ref int num, int num2)
        {
            num += num2;
        }

        public static void OutroExemplo(MensagemRetornoNaoAutorizado entrada)
        {
            entrada.Mensagem = "modifiquei! Simples assim";
        }

        public static T TratarNulo<T>(object valor)
        {
            if (DBNull.Value.Equals(valor))
            {
                return default(T);
            }
            else
            {
                return (T)valor;
            }
        }

    }

    public class MensagemRetornoNaoAutorizado
    {
        public string? Mensagem { get; set; }
    }

    public class MensagemRetornoSucesso
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
    }

}
