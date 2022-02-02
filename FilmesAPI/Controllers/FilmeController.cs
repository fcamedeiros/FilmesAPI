using FilmesAPI.Data;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Collections.Generic;
using FilmesAPI.Data.Dtos;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {
        private FilmeContext _context;

        public FilmeController(FilmeContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult AdicionaFilme([FromBody] CreateFilmeDto filmeDto)
        {
            Filme filme = new Filme
            {
                Titulo = filmeDto.Titulo,
                Genero = filmeDto.Genero,
                Duracao = filmeDto.Duracao,
                Diretor = filmeDto.Diretor
            };

            _context.Filmes.Add(filme);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaFilmePorId), new { Id = filme.Id }, filme);
        }

        [HttpGet]
        public IEnumerable<Filme> RecuperaFilmes()
        {
            return _context.Filmes;
        }

        private Filme GetFilme(int id)
        {
            return _context.Filmes.FirstOrDefault(filme => filme.Id == id);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaFilmePorId(int id)
        {
            Filme filme = GetFilme(id);

            if (filme == null)
                return NotFound();

            ReadFilmeDto filmeDto = new ReadFilmeDto
            {
                Titulo = filme.Titulo,
                Diretor = filme.Diretor,
                Duracao = filme.Duracao,
                Id = filme.Id,
                Genero = filme.Genero,
                HoraDaConsulta = System.DateTime.Now
            };

            return Ok(filmeDto);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaFilme(int id, [FromBody] UpdateFilmeDto filmeDto)
        {
            Filme filme = GetFilme(id);

            if (filme == null)
                return NotFound();

            filme.Titulo = filmeDto.Titulo;
            filme.Genero = filmeDto.Genero;
            filme.Diretor = filmeDto.Diretor;
            filme.Duracao = filmeDto.Duracao;

            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
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
