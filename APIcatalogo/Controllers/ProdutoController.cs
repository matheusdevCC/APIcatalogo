using Microsoft.AspNetCore.Mvc;
using APIcatalogo.Models;
using APIcatalogo.Context;
using Microsoft.EntityFrameworkCore;
namespace APIcatalogo.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ProdutoController : Controller
    {
        private readonly AppDbContext _context;

        public ProdutoController(AppDbContext context)
        { 
        _context = context;
        }

        [HttpGet("Primeiro")]
        public ActionResult<Produto> GetPrimeiro() 
        {
         var produtos = _context.Produtos.FirstOrDefault();

            if(produtos is null) 
            {
             return NotFound();
            }

            return produtos;
        
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Produto>>> Get() 
        {
            var Produtos = _context.Produtos.ToListAsync();
            if(Produtos is null) 
            {
                return NotFound("Produtos não encontrados...");
            }
            return await Produtos;
            
        }

        [HttpGet("{id:int:min(1)}", Name="ObterProduto")]

        public async Task<ActionResult<Produto>> Get(int id) 
        {
            var Produto = _context.Produtos.FirstOrDefaultAsync(p => p.ProdutoId == id);
            if(Produto is null) 
            {
                return NotFound("Produto não encontrado!");
            }
            return await Produto;
        
        }
        [HttpPost]
        public ActionResult Post(Produto produto) 
        {
            if(produto is null) 
            {

                return BadRequest();
            }
            _context.Produtos.Add(produto);
            _context.SaveChanges();
        
        return new CreatedAtRouteResult("ObterProduto", new {id = produto.ProdutoId}, produto);
        
        }
        [HttpPut("{id:int}")]
        
        public ActionResult Put(int id, Produto produto)
        {
           if(id != produto.ProdutoId) 
            {
                return BadRequest();
            }
            _context.Entry(produto).State = EntityState.Modified; 
            _context.SaveChanges();
            return Ok(produto);

        }
        [HttpDelete("{id:int}")]

        public ActionResult Delete(int id) 
        { 
            var produto = _context.Produtos.FirstOrDefault(p=> p.ProdutoId==id);

            if(produto is null) 
            {
                return NotFound("Não encontrado!");
            }
                
            _context.Produtos.Remove(produto);
            _context.SaveChanges();

            return Ok(produto);
        
        }

    }
}
