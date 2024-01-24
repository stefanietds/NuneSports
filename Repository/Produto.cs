using System.Data.SqlClient;
using Dapper;


namespace NuneSports.Repository
{
    public class Produto : IRepository.IProduto
    {
        private readonly string _connectionString;

        public Produto(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("SqlConnection");
        }

        public async Task<List<Model.Produto>> GetAllProduto()
        {
            try
            {
                using(var con = new SqlConnection(_connectionString))
                {
                    var sql = "SELECT * FROM produto";
                    var produto = await con.QueryAsync<Model.Produto>(sql);
                    return produto.ToList();
                }
            }
            catch (Exception)
            {
                return new List<Model.Produto>();
            }

        }

        public async Task<Model.Produto?> ProdutoId(int codigo)
        {
            try
            {
                using(var con = new SqlConnection(_connectionString))
                {
                    var sql = "SELECT Codigo_Produto, Nome_Produto, Descricao_Produto, Preco_Produto FROM produto WHERE Codigo_Produto = @codigo";
                    IEnumerable<Model.Produto?> produto = await con.QueryAsync<Model.Produto>(sql, new { codigo });
                    return produto.FirstOrDefault();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<bool> CreateProduto(Model.Produto produto)
        {
            try
            {
                using (var con = new SqlConnection(_connectionString))
                {
                    var sql = "INSERT INTO Produto (Nome_Produto, Descricao_Produto, Preco_Produto) VALUES (@Nome, @Descricao, @Preco);";
                
                    await con.ExecuteAsync(sql, new
                    {
                        Nome = produto.Nome_Produto,
                        Descricao = produto.Descricao_Produto,
                        Preco = produto.Preco_Produto
                    });
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> UpdateProduto(int codigo, string nome, string descricao, decimal preco)
        {
            try
            {
                using (var con = new SqlConnection(_connectionString))
                {
                    string sql = "UPDATE produto SET nome_produto = @nome, descricao_produto = @descricao, preco_produto = @preco WHERE codigo_produto = @codigo;";

                    int affectedRows = await con.ExecuteAsync(sql, new { codigo, nome, descricao, preco });

                    return affectedRows > 0;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> Delete(int codigo)
        {
            bool produtoExiste = await ExisteProduto(codigo);

            if (!produtoExiste)
            {
                return false;
            }
            
            try
            {
                using (var con = new SqlConnection(_connectionString))
                {
                    string sql = "DELETE FROM produto WHERE codigo_produto = @codigo";
                    await con.ExecuteAsync(sql, new { codigo });
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> ExisteProduto(int codigo)
        {
            using (var con = new SqlConnection(_connectionString))
            {
                string sql = "SELECT 1 FROM produto WHERE codigo_produto = @codigo";
                return await con.QueryFirstOrDefaultAsync<int>(sql, new { codigo }) == 1;
            }
        }
        
    }
}