using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CursoAvanadeDotnetAngular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TesteController : ControllerBase
    {

        [HttpGet]
        [Route("/ConverterString")]
        public string Get(int parametroEntrada)
        {
            return (parametroEntrada.ToString());
        }

        [HttpGet]
        [Route("/ConverterInteiro")]
        public int Get(string parametroEntrada)
        {
            return Int32.Parse(parametroEntrada);
        }

        [HttpGet]
        [Route("/TratamentoRetorno")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MensagemRetornoSucesso))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(MensagemRetornoNaoAutorizado))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public IActionResult Tratamentos(
            string usuario,
            int id,
            string senha)
        {
            int idLocal = 0;

            if (usuario != "malheiro" || senha != "123")
            {
                return Unauthorized(
                        new MensagemRetornoNaoAutorizado()
                        {
                            Mensagem = "Usuário Não autorizado"
                        });
            }

            try
            {
                idLocal = Convert.ToInt32(id);
            }

            catch (Exception ex)
            {
                return BadRequest($"Não dá para converter o {id} para inteiro");
                throw;
            }

            if (idLocal <= 0)
            {
                return NoContent();
            }

            return Ok(new MensagemRetornoSucesso()
            {
                Id = idLocal++,
                Nome = usuario,
            });
        }

        [HttpDelete]
        [Route("/Deletar")]
        public IActionResult Delete(int id)
        {
            return Ok();
        }

        [HttpPatch]
        [Route("/Modificar")]
        public IActionResult Modificar(int id)
        {
            return Ok();

        }

        [HttpPut]
        [Route("/Atualizar")]
        public IActionResult Edit(int id)
        {
            return Ok();

        }

        //[HttpPost]
        //[Route("/Criar")]
        //public IActionResult Criar()
        //{
        //    return Ok();

        //}

    }
}

public class MensagemRetornoNaoAutorizado
{
    public string? Mensagem { get; set; }
}

public class MensagemRetornoSucesso
{
    public int Id { get; set; }
    public string Nome { get; set; }
}
