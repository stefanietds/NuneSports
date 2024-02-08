using Microsoft.AspNetCore.Mvc;
using NuneSports.Model;

namespace NuneSports.Service;

public interface IProdutoService
{
    Task<IEnumerable<Produto>> GetProducts();
    Task<Produto> GetProductById(int id);
    Task<Produto> AddProduct(Produto product);
    Task UpdateProduct(Produto product);
    Task RemoveProduct(int id);
}