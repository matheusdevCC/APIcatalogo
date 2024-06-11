using Microsoft.AspNetCore.Mvc;
using APIcatalogo.Models;
using APIcatalogo.Context;
using Microsoft.EntityFrameworkCore;
namespace APIcatalogo.Controllers
{
    [ApiController]
    [Route("Controller")]

    public class ProdutoController : Controller
    {
        private readonly AppDbContext _context;

        public ProdutoController(AppDbContext context)
        { 
        _context = context;
        }

        [HttpGet]

        public ActionResult<IEnumerable<Produto>> Get() 
        {
            var Produtos = _context.Produtos.ToList();
            if(Produtos is null) 
            {
                return NotFound("Produtos não encontrados...");
            }
            return Produtos;
            
        }

        [HttpGet("{id:int}", Name="ObterProduto")]
        public ActionResult<Produto> Get(int id) 
        {
            var Produto = _context.Produtos.FirstOrDefault(p => p.ProdutoId == id);
            if(Produto is null) 
            {
                return NotFound("Produto não encontrado!");
            }
            return Produto;
        
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
