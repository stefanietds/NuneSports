using Microsoft.EntityFrameworkCore;
using NuneSports.Model;

namespace NuneSports.Context;

public class AppDbContext: DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options ) : base( options )
    {           
    }
   
    public DbSet<Produto>? Produtos { get; set; }
}