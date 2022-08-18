using System;
using System.Threading.Tasks;
using BlogAPI.Src.Modelos;
using BlogAPI.Src.Repositorios;
using Microsoft.AspNetCore.Mvc;

namespace BlogAPI.Src.Controladores
{
    [ApiController]
    [Route("api/Temas")]
    [Produces("application/json")]
    public class TemaControlador : ControllerBase
    {
        #region Atributos
        private readonly ITema _repositorio;
        #endregion

        #region Construtores
        public TemaControlador(ITema repositorio)
        {
            _repositorio = repositorio;
        }
        #endregion

        #region Métodos

        /// <summary>
        /// Pegar todas os temas
        /// </summary>
        /// <returns>ActionResult</returns>
        /// <response code="200">Retorna todas os temas.</response>
        /// <response code="204">Não há temas</response>

        [HttpGet]
        public async Task<ActionResult> PegarTodosTemasAsync()
        {
            var lista = await _repositorio.PegarTodosTemasAsync();
            if (lista.Count < 1) return NoContent();
            return Ok(lista);
        }

        /// <summary>
        /// Pegar todos os temas por ID
        /// </summary>
        /// <param name="idTema">Id da postagem</param>
        /// <returns>ActionResult</returns>
        /// <response code="200">Retorna todos os temas.</response>
        /// <response code="404">Não exite tema relacionado a esse ID </response>

        [HttpGet("id/{idTema}")]
        public async Task<ActionResult> PegarTemaPeloIdAsync([FromRoute] int idTema)
        {
            try
            {
                return Ok(await _repositorio.PegarTemaPeloIdAsync(idTema));
            }
            catch (Exception ex)
            {
                return NotFound(new { Mensagem = ex.Message });
            }
        }

        /// <summary>
        /// Criar novo Tema
        /// </summary>
        /// <param name="tema">Contrutor para criar tema</param>
        /// <returns>ActionResult</returns>
        /// <remarks>
        /// Exemplo de requisição:
        ///
        /// POST /api/Temas
        /// {
        /// "descricao": "DESCRIÇÂO 1"
        /// }
        ///
        /// </remarks>
        /// <response code="201">Retorna a postagem criada</response>

        [HttpPost]
        public async Task<ActionResult> NovoTemaAsync([FromBody] Tema tema)
        {
            await _repositorio.NovoTemaAsync(tema);
            return Created($"api/Temas", tema);
        }

        /// <summary>
        /// Atulizar o tema
        /// </summary>
        /// <param name="tema">Contrutor para atualizar o tema/param>
        /// <returns>ActionResult</returns>
        /// <remarks>
        /// Exemplo de requisição:
        ///
        /// PUT /api/Temas
        /// {
        /// "descricao": "DESCRIÇÂO 1",
        /// }
        ///
        /// </remarks>
        /// <response code="200">Retorna o tema atualizado</response>
        /// <response code="400">Tema não encontrado</response>

        [HttpPut]
        public async Task<ActionResult> AtualizarTema([FromBody] Tema tema)
        {
            try
            {
                await _repositorio.AtualizarTemaAsync(tema);
                return Ok(tema);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Mensagem = ex.Message });
            }
        }

        /// <summary>
        /// Apagar o tema pelo ID
        /// </summary>
        /// <param name="idTema">Id do tema</param>
        /// <returns>ActionResult</returns>
        /// <response code="204">Tema deletado.</response>
        /// <response code="404">Tema não encontrado </response>

        [HttpDelete("deletar/{idTema}")]
        public async Task<ActionResult> DeletarTema([FromRoute] int idTema)
        {
            try
            {
                await _repositorio.DeletarTemaAsync(idTema);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(new { Mensagem = ex.Message });
            }
        }

            #endregion
        }
}
