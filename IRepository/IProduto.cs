using NuneSports.Model;

namespace NuneSports.IRepository;

public interface IProduto
{
    Task<List<Model.Produto>> GetAllProduto();
    Task<Produto?> ProdutoId(int codigo);
    Task<bool> CreateProduto(Model.Produto produto);
    Task<bool> UpdateProduto(int codigo, string nome, string descricao, decimal preco);
    Task<bool> Delete(int codigo);
    Task<bool> ExisteProduto(int codigo);
}