using FilmesAPI.Data;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Collections.Generic;
using FilmesAPI.Data.Dtos;
using AutoMapper;
using Microsoft.AspNetCore.Http;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    public class FilmeController : ControllerBase
    {
        private FilmeContext _context;
        private IMapper _mapper;

        public FilmeController(FilmeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        private Filme GetFilme(int id)
        {
            return _context.Filmes.FirstOrDefault(filme => filme.Id == id);
        }

        /// <summary>
        /// Adiciona um filme no Banco de Dados
        /// </summary>
        /// <param name="filmeDto">JSON com os dados do filme que será armazenado</param>
        /// <returns>O novo filme criado</returns>
        /// <remarks>
        /// Exemplo da request:
        /// 
        /// POST /filme
        /// {
        ///     "Titulo"  : "O senhor dos aneis",
        ///     "Genero"  : "Aventura",
        ///     "Diretor" : "Peter Jackson",
        ///     "Duracao" : 180
        /// }
        /// </remarks>
        /// <response code="201">Retorna o filme recém criado</response>
        /// <response code="400">Se o filme é nulo</response>
        /// 
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult AdicionaFilme([FromBody] CreateFilmeDto filmeDto)
        {
            Filme filme = _mapper.Map<Filme>(filmeDto);

            _context.Filmes.Add(filme);
            _context.SaveChanges();

            return CreatedAtAction(nameof(RecuperaFilmePorId), new { Id = filme.Id }, filme);
        }

        /// <summary>
        /// Recupera a lista de filmes presentes no Banco de Dados
        /// </summary>
        /// <returns>Todos os filmes presentes na tabela</returns>
        /// <remarks>
        /// Exemplo da request:
        /// 
        /// GET /filme
        /// </remarks>
        /// <response code="200">Retorna uma lista vazia (se não existir cadastros) ou uma lista de filmes</response>
        /// 
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IEnumerable<Filme> RecuperaFilmes()
        {
            return _context.Filmes;
        }

        /// <summary>
        /// Recupera um filme pelo seu identificador
        /// </summary>
        /// <param name="id">Identificador do filme armazenado</param>
        /// <returns>Retorna o filme encontrado com o identificador informado</returns>
        /// <remarks>
        /// Exemplo da request:
        /// 
        /// GET /filme/1
        /// </remarks>
        /// <response code="200">Retorna o filme encontrado</response>
        /// <response code="404">Se o filme não for localizado</response>
        /// 
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult RecuperaFilmePorId(int id)
        {
            Filme filme = GetFilme(id);

            if (filme == null)
                return NotFound();

            ReadFilmeDto filmeDto = _mapper.Map<ReadFilmeDto>(filme);
            filmeDto.HoraDaConsulta = System.DateTime.Now;

            return Ok(filmeDto);
        }

        /// <summary>
        /// Atualiza os dados de um filme cadastrado
        /// </summary>
        /// <param name="id">Identificador do filme armazenado</param>
        /// <param name="filmeDto">JSON com os dados da atualização</param>
        /// <returns></returns>
        /// <remarks>
        /// Exemplo da request:
        /// 
        /// PUT /filme/3
        /// {
        ///     "Titulo"  : "Missão Impossível",
        ///     "Genero"  : "Aventura",
        ///     "Diretor" : "Brian De Palma",
        ///     "Duracao" : 110
        /// }
        /// </remarks>
        /// <response code="204">Corpo da resposta vazia</response>
        /// <response code="404">Se o filme não for localizado</response>
        /// 
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult AtualizaFilme(int id, [FromBody] UpdateFilmeDto filmeDto)
        {
            Filme filme = GetFilme(id);

            if (filme == null)
                return NotFound();

            _mapper.Map(filmeDto, filme);

            _context.SaveChanges();

            return NoContent();
        }

        /// <summary>
        /// Elimina um filme cadastrado
        /// </summary>
        /// <param name="id">Identificador do filme armazenado</param>
        /// <returns></returns>
        /// <remarks>
        /// Exemplo da request:
        /// 
        /// DELETE /filme/3
        /// </remarks>
        /// <response code="204">Corpo da resposta vazia</response>
        /// <response code="404">Se o filme não for localizado</response>
        /// 
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeletaFilme(int id)
        {
            Filme filme = GetFilme(id);

            if (filme == null)
                return NotFound();

            _context.Remove(filme);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
