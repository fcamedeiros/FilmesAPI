using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {
        private static List<Filme> filmes = new List<Filme>();
        private static int id = 1;

        [HttpPost]
        public IActionResult AdicionaFilme([FromBody] Filme filme)
        {
            filme.Id = id++;
            filmes.Add(filme);

            return CreatedAtAction(nameof(RecuperaFilmePorId), new { Id = filme.Id }, filme);
        }

        [HttpGet]
        public IActionResult RecuperaFilmes()
        {
            return Ok(filmes);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaFilmePorId(int id)
        {
            Filme filme = filmes.Find(filme => filme.Id == id);

            if (filme == null)
                return NotFound();

            return Ok(filme);
        }
    }
}
