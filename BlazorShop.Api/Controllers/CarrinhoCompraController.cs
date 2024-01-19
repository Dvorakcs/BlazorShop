using BlazorShop.Api.Mappings;
using BlazorShop.Api.Repositories.Interfaces;
using BlazorShop.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace BlazorShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarrinhoCompraController : ControllerBase
    {
        private readonly ICarrinhoCompraRepository carrinhoCompraRepository;
        private readonly IProdutoRepository produtoRepository;

        private ILogger<CarrinhoCompraController> logger;

        public CarrinhoCompraController(
            ICarrinhoCompraRepository carrinhoCompraRepository, 
            IProdutoRepository produtoRepository, 
            ILogger<CarrinhoCompraController> logger
        )
        {
            this.carrinhoCompraRepository = carrinhoCompraRepository;
            this.produtoRepository = produtoRepository;
            this.logger = logger;
        }


        [HttpGet]
        [Route("{usuarioId}/GetItens")]
        public async Task<ActionResult<IEnumerable<CarrinhoItemDto>>> GetItens(string usuarioId)
        {
            try
            {
                var carrinhoItens = await carrinhoCompraRepository.GetItems(usuarioId);
                if(carrinhoItens is null)
                {
                    return NoContent();
                }
                var produtos = await produtoRepository.GetItens();
                if (produtos is null)
                {
                    throw new Exception("Produtos nao existem");
                }
                var carrinhoItensDto = carrinhoItens.ConverterCarrinhoItensParaDto(produtos);

                return Ok(carrinhoItensDto);
            }
            catch (Exception ex)
            {
                logger.LogError("## erro ao obter itens do carrinho");
                return StatusCode(500,ex);
            }
        }
        [HttpGet("{id:int}")]  
        public async Task<ActionResult<CarrinhoItemDto>> GetItem(int id)
        {
            try
            {
                var carrinhoItem = await carrinhoCompraRepository.GetItem(id);
                if (carrinhoItem is null)
                {
                    return NoContent();
                }
                var produtos = await produtoRepository.GetItem(carrinhoItem.ProdutoId);
                if (produtos is null)
                {
                    throw new Exception("Produtos nao existem");
                }
                var carrinhoItensDto = carrinhoItem.ConverterCarrinhoItenParaDto(produtos);

                return Ok(carrinhoItensDto);
            }
            catch (Exception ex)
            {
                logger.LogError("## erro ao obter itens do carrinho");
                return StatusCode(500, ex);
            }
        }

        [HttpPost]
        public async Task<ActionResult<CarrinhoItemDto>> postItem([FromBody] CarrinhoItemAdicionaDto carrinhoItemAdicionaDto)
        {
            try
            {
                var novoCarrinhoItem = await carrinhoCompraRepository.AdicionarItem(carrinhoItemAdicionaDto);

                if(novoCarrinhoItem is null)
                {
                    return NoContent();
                }

                var produto = await produtoRepository.GetItem(novoCarrinhoItem.ProdutoId);
                if (produto is null)
                {
                    return NoContent();
                }

                var novoCarrinhoItemDto = novoCarrinhoItem.ConverterCarrinhoItenParaDto(produto);
                return CreatedAtAction(nameof(GetItem), new { id = novoCarrinhoItem.Id }, novoCarrinhoItemDto);
            }
            catch (Exception ex)
            {

                logger.LogError("## erro ao criar um novo item no carrinho");
                return StatusCode(500, ex);
            }
        }
    }
}
