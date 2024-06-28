using APIcatalogo.Context;
using APIcatalogo.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace APIcatalogo.Repositories
{
    public class ProdutoRepository : IprodutoRepository
    {
        private readonly AppDbContext _context;

        public ProdutoRepository(AppDbContext context) 
        {
            _context = context;
        }

        public IEnumerable<Produto> GetProdutos()
        {
            var produto = _context.Produtos.ToList(); 
            return produto;

        }

        public Produto GetProdutosID(int id)
        {
            var prodId = _context.Produtos.FirstOrDefault(x=> x.ProdutoId == id);
            return prodId;

        }

        public Produto Create(Produto produto)
        {
          if(produto == null) 
          {
             throw new ArgumentNullException(nameof(produto));
          }
            _context.Produtos.Add(produto);
            _context.SaveChanges();
            return produto;
        }       

        public Produto Update(Produto produto)
        {
           if(produto is null) 
           {
                throw new ArgumentNullException(nameof(produto));
           }
           _context.Entry(produto).State = EntityState.Modified;
            _context.SaveChanges();
            return produto;
        }

        public Produto Delete(int id)
        {
            var prod = _context.Produtos.Find(id);
            if(prod == null) 
            {
                throw new ArgumentNullException(nameof(prod));
            }
            _context.Produtos.Remove(prod);
            _context.SaveChanges();
            return prod;
        }
    }
}
