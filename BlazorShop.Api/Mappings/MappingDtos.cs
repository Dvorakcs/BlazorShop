

using BlazorShop.Api.Entities;
using BlazorShop.Models.DTOs;

namespace BlazorShop.Api.Mappings
{
    public static class MappingDtos
    {

        public static IEnumerable<CategoriaDto> CoverterCategoriasParaDto(this IEnumerable<Categoria> categorias)
        {
            return (from categoria in categorias
                    select new CategoriaDto
                    {
                        IconCSS = categoria.IconCSS,
                        Id = categoria.Id,
                        Nome = categoria.Nome,
                    }).ToList();
        }
        public static IEnumerable<ProdutoDto> CoverterProdutosParaDto(this IEnumerable<Produto> Produtos)
        {
            return (from produto in Produtos
                    select new ProdutoDto
                    {
                        Id = produto.Id,
                        Nome = produto.Nome,
                        CategoriaId = produto.CategoriaId,
                        CategoriaNome = produto.Categoria?.Nome,
                        Quantidade = produto.Quantidade,
                        Descricao = produto.Descricao,
                        ImagemUrl = produto.ImagemUrl,
                        Preco = produto.Preco,
                    }).ToList();
        }

        public static ProdutoDto CoverterProdutoParaDto(this Produto Produto)
        {
            return new ProdutoDto
            {
                Id = Produto.Id,
                Nome = Produto.Nome,
                CategoriaId = Produto.CategoriaId,
                CategoriaNome = Produto.Categoria?.Nome,
                Quantidade = Produto.Quantidade,
                Descricao = Produto.Descricao,
                ImagemUrl = Produto.ImagemUrl,
                Preco = Produto.Preco,
            };
        }

        public static IEnumerable<CarrinhoItemDto> ConverterCarrinhoItensParaDto(this IEnumerable<CarrinhoItem> carrinhoItens, IEnumerable<Produto> produtos)
        {
            return (from carrinhoItem in carrinhoItens
                    join produto in produtos
                    on carrinhoItem.ProdutoId equals produto.Id
                    select new CarrinhoItemDto
                    {
                        Id = carrinhoItem.Id,
                        ProdutoId = produto.Id,
                        ProdutoNome = produto.Nome,
                        ProdutoDescricao = produto.Descricao,
                        ProdutoImagemURL = produto.ImagemUrl,
                        Preco = produto.Preco,
                        CarrinhoId = carrinhoItem.CarrinhoId,
                        Quantidade = produto.Quantidade,
                        PrecoTotal = produto.Preco * carrinhoItem.Quantidade
                    }).ToList();
        }
        public static CarrinhoItemDto ConverterCarrinhoItenParaDto(this CarrinhoItem carrinhoItens, Produto produtos)
        {
            return new CarrinhoItemDto
                    {
                        Id = carrinhoItens.Id,
                        ProdutoId = produtos.Id,
                        ProdutoNome = produtos.Nome,
                        ProdutoDescricao = produtos.Descricao,
                        ProdutoImagemURL = produtos.ImagemUrl,
                        Preco = produtos.Preco,
                        CarrinhoId = carrinhoItens.CarrinhoId,
                        Quantidade = produtos.Quantidade,
                        PrecoTotal = produtos.Preco * carrinhoItens.Quantidade
                    };
        }
    }
}
