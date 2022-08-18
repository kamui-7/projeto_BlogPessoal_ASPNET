using BlogAPI.Src.Modelos;
using BlogAPI.Src.Repositorios;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace BlogAPI.Src.Controladores
{
    [ApiController]
    [Route("api/Postagens")]
    [Produces("application/json")]
    public class PostagemControlador : ControllerBase
    {
        #region Atributos
        private readonly IPostagem _repositorio;
        #endregion

        #region Construtores
        public PostagemControlador(IPostagem repositorio)
        {
            _repositorio = repositorio;
        }
        #endregion

        #region Métodos

        /// <summary>
        /// Pegar todas as postagens
        /// </summary>
        /// <returns>ActionResult</returns>
        /// <response code="200">Retorna todas as postagens.</response>
        /// <response code="404">Não há postagens</response>

        [HttpGet]
        public async Task<ActionResult> PegarTodasPostagensAsync()
        {
            var lista = await _repositorio.PegarTodasPostagensAsync();
            if (lista.Count < 1) return NoContent();
            return Ok(lista);
        }

        /// <summary>
        /// Pegar todas as postagens por ID
        /// </summary>
        /// <param name="idPostagem">Id da postagem</param>
        /// <returns>ActionResult</returns>
        /// <response code="200">Retorna todas as postagens.</response>
        /// <response code="404">Não exite postagem relacionada a esse ID </response>

        [HttpGet("id/{idPostagem}")]
        public async Task<ActionResult> PegarPostagemPeloIdAsync([FromRoute] int idPostagem)
        {
            try
            {
                return Ok(await _repositorio.PegarPostagemPeloIdAsync(idPostagem));
            }
            catch (Exception ex)
            {
                return NotFound(new { Mensagem = ex.Message });
            }
        }

        /// <summary>
        /// Criar nova Postagem
        /// </summary>
        /// <param name="postagem">Contrutor para criar postagem</param>
        /// <returns>ActionResult</returns>
        /// <remarks>
        /// Exemplo de requisição:
        ///
        /// POST /api/Postagens
        /// {
        /// "titulo": "TITULO 1",
        /// "descricao": "DESCRIÇÂO 1",
        /// "foto": "FOTO URL",
        /// "criador": "USUARIO 1",
        /// "tema": "TEMA 1"
        /// }
        ///
        /// </remarks>
        /// <response code="201">Retorna a postagem criada</response>
        /// <response code="400">Postagem ja cadastrada</response>

        [HttpPost]
        public async Task<ActionResult> NovaPostagemAsync([FromBody] Postagem postagem)
        {
            try
            {
                await _repositorio.NovaPostagemAsync(postagem);
                return Created($"api/Postagens", postagem);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Mensagem = ex.Message });
            }
        }

        /// <summary>
        /// Atulizar a Postagem
        /// </summary>
        /// <param name="postagem">Contrutor para atualizar postagem</param>
        /// <returns>ActionResult</returns>
        /// <remarks>
        /// Exemplo de requisição:
        ///
        /// PUT /api/Postagens
        /// {
        /// "titulo": "TITULO 1",
        /// "descricao": "DESCRIÇÂO 1",
        /// "foto": "FOTO URL",
        /// "criador": "USUARIO 1",
        /// "tema": "TEMA 1"
        /// }
        ///
        /// </remarks>
        /// <response code="200">Retorna a postagem atualizada</response>
        /// <response code="400">Postagem não encontrada</response>

        [HttpPut]
        public async Task<ActionResult> AtualizarPostagemAsync([FromBody] Postagem postagem)
        {
            try
            {
                await _repositorio.AtualizarPostagemAsync(postagem);
                return Ok(postagem);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Mensagem = ex.Message });
            }
        }

        /// <summary>
        /// Apafar a postagem pelo ID
        /// </summary>
        /// <param name="idPostagem">Id da postagem</param>
        /// <returns>ActionResult</returns>
        /// <response code="204">Postagem deletada.</response>
        /// <response code="404">Postagem não encontrada </response>

        [HttpDelete("deletar/{idPostagem}")]
        public async Task<ActionResult> DeletarPostagem([FromRoute] int idPostagem)
        {
            try
            {
                await _repositorio.DeletarPostagemAsync(idPostagem);
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
