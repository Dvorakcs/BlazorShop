using BlazorShop.Api.Mappings;
using BlazorShop.Api.Repositories.Interfaces;
using BlazorShop.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace BlazorShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutosController(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProdutoDto>>> GetItems()
        {
            try
            {
                var produtos = await _produtoRepository.GetItens();
                if(produtos is null)
                {
                    return NotFound("Produtos nao localizado");
                }
                
                return Ok(produtos.CoverterProdutosParaDto());
               
            }
            catch (Exception)
            {

                return StatusCode(500, "erro ao acessar a base de dados");
            }
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<ProdutoDto>> GetItem(int id)
        {
            try
            {
                var produtos = await _produtoRepository.GetItem(id);
                if (produtos is null)
                {
                    return NotFound("Produto nao localizado");
                }

                return Ok(produtos.CoverterProdutoParaDto());

            }
            catch (Exception)
            {

                return StatusCode(500, "erro ao acessar a base de dados");
            }
        }
        [HttpGet]
        [Route("GetItensPorCategoria/{categoriaId}")]
        public async Task<ActionResult<IEnumerable<ProdutoDto>>> GetItensPorCategoria(int categoriaId)
        {
            try
            {
                var produtos = await _produtoRepository.GetItensPorCategoria(categoriaId);       
                return Ok(produtos.CoverterProdutosParaDto());

            }
            catch (Exception)
            {

                return StatusCode(500, "erro ao acessar a base de dados");
            }
        }
    }
}
