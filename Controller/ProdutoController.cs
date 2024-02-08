using Microsoft.AspNetCore.Mvc;
using NuneSports.Model;
using NuneSports.Service;

namespace NuneSports.Controller
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService _produtoService;

        public ProdutoController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Produto>>> GetAllProdutos()
        {
            try
            {
                var product = await _produtoService.GetProducts();
                if (product is null)
                    return NotFound("Product not found");

                return Ok(product);
            }
            catch
            {
                return BadRequest("error");
            }
        }
        
        [HttpGet("{id}", Name = "GetProduct")]
        public async Task<ActionResult<Produto>> GetById(int id)
        {
            try
            {
                var product = await _produtoService.GetProductById(id);
                if (product is null)
                    return NotFound("Product not found");

                return Ok(product);
            }
            catch
            {
                return BadRequest();
            }
        } 
        
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Produto product)
        {
            try
            {
                if (product is null)
                    return BadRequest("product is invalid");

                await _produtoService.AddProduct(product);

                return Ok(product);
            }
            catch
            {
                return BadRequest();
            }
        }
        
        [HttpPut]
        public async Task<ActionResult<Produto>> Put([FromBody] Produto product)
        {
            try
            {
                if (product is null)
                    return NotFound("Product not found");

                await _produtoService.UpdateProduct(product);

                return Ok(product);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Produto>> Delete(int id)
        {
            try
            {
                var product = await _produtoService.GetProductById(id);

                if (product is null)
                    return NotFound("Product not found");
                

                await _produtoService.RemoveProduct(id);

                return Ok(product);
            }
            catch
            {
                return BadRequest();
            }
        }
        
    }
}