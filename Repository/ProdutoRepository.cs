using Microsoft.EntityFrameworkCore;
using NuneSports.Context;
using NuneSports.Model;

namespace NuneSports.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        protected readonly AppDbContext _appDbContext;

        public ProdutoRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<IEnumerable<Produto>> GetAll()
        {
            return await _appDbContext.Produtos.ToListAsync();
        }

        public async Task<Produto> GetById(int id)
        {
            return await _appDbContext.Produtos.FirstOrDefaultAsync(x => x.Codigo_Produto == id);
        }

        public async Task<Produto> Create(Produto product)
        {
            _appDbContext.Produtos.Add(product);
            await _appDbContext.SaveChangesAsync();
            return product;
        }

        public async Task<Produto> Update(Produto product)
        {
            _appDbContext.Entry(product).State = EntityState.Modified;
            await _appDbContext.SaveChangesAsync();
            return product;
        }

        public async Task<Produto> Delete(int id)
        {
            var product = await GetById(id);
            _appDbContext.Produtos.Remove(product);
            await _appDbContext.SaveChangesAsync();
            return product;
        }
        
        
    }
}