using NuneSports.Model;
using NuneSports.Repository;

namespace NuneSports.Service;

public class ProdutoService : IProdutoService
{
    private IProdutoRepository _produtoRepository;

    public ProdutoService(IProdutoRepository produtoRepository)
    {
        _produtoRepository = produtoRepository;
    }
    
    public async Task<IEnumerable<Produto>> GetProducts()
    {
        return await _produtoRepository.GetAll();
    }

    public async Task<Produto> GetProductById(int id)
    {
        return await _produtoRepository.GetById(id);
    }

    public async Task<Produto> AddProduct(Produto product)
    {
        return await _produtoRepository.Create(product);
    }

    public async Task UpdateProduct(Produto product)
    {
        await _produtoRepository.Update(product);
    }

    public async Task RemoveProduct(int id)
    {
        await _produtoRepository.Delete(id);
    }
    
}