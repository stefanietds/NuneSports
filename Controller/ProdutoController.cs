using Microsoft.AspNetCore.Mvc;
using NuneSports.Model;

namespace NuneSports.Controller
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly Repository.Produto _produto;

        public ProdutoController(Repository.Produto produto)
        {
            _produto = produto;
        }


        [HttpGet]
        public async Task<ActionResult<List<Produto>>> GetAllProdutos()
        {
            var produtos = await _produto.GetAllProduto();
            return produtos.Any()? Ok(produtos) : NotFound("Nenhum produto localizado!");
        }
        
        [HttpGet("{codigo}")]
        public async Task<IResult> ProdutoId(int codigo)
        {
            var produto = await _produto.ProdutoId(codigo);
            return produto is not null ? Results.Ok(produto) : Results.NotFound("O produto não foi encontrado") ;
        }
        
        [HttpPost]
        public async Task<IResult> CreateProduto(Produto produto)
        {
            bool result = await _produto.CreateProduto(produto);
            return result ? Results.Ok("Produto criado!") : Results.BadRequest("Não foi possivel criar o produto.");
        }
        
        [HttpPut("{codigo}/{nome}/{descricao}/{preco}")]
        public async Task<IResult> UpdateProduto(int codigo, string nome, string descricao, decimal preco)
        {
            bool result = await _produto.UpdateProduto(codigo, nome, descricao, preco);
            return result ? Results.Ok("Produto atualizado!") : Results.NotFound("Não foi possivel atualizar o produto.");
        }
        
        [HttpDelete("{codigo}")]
        public async Task<IResult> DeleteProduto(int codigo)
        {
            bool result = await _produto.Delete(codigo);
            return result ? Results.Ok("Produto deletado com sucesso!") : Results.NotFound("Não foi possivel deletar o produto.");
        }
        
    }
}