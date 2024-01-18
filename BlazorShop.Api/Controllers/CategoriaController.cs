using BlazorShop.Api.Mappings;
using BlazorShop.Api.Repositories;
using BlazorShop.Api.Repositories.Interfaces;
using BlazorShop.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaRepository _repository;

        public CategoriaController(ICategoriaRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoriaDto>>> GetItems()
        {
            try
            {
                var Categoria = await _repository.GetCategorias();
                if (Categoria is null)
                {
                    return NotFound("Categoria nao localizado");
                }

                return Ok(Categoria.CoverterCategoriasParaDto());

            }
            catch (Exception)
            {

                return StatusCode(500, "erro ao acessar a base de dados");
            }
        }
    }
}
