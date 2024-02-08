using NuneSports.Model;

namespace NuneSports.Repository;

public interface IProdutoRepository
{
    Task<IEnumerable<Produto>> GetAll();
    Task<Produto> GetById(int id);
    Task<Produto> Create(Produto product);
    Task<Produto> Update(Produto product);
    Task<Produto> Delete(int id);
}