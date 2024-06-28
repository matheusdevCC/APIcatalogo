using Microsoft.AspNetCore.Mvc;
using APIcatalogo.Models;
using APIcatalogo.Context;
using Microsoft.EntityFrameworkCore;
using APIcatalogo.Repositories;
namespace APIcatalogo.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ProdutoController : Controller
    {
        private readonly IprodutoRepository _repository;

        private readonly ILogger<ProdutoController> _logger;

        public ProdutoController(IprodutoRepository repository, ILogger<ProdutoController> ilogger) 
        {
        _repository = repository;
         _logger = ilogger;
        
        }
               
        [HttpGet("Primeiro")]
        public ActionResult<IEnumerable<Produto>> Get() 
        {
         var produtos = _repository.GetProdutos();
         return Ok(produtos);
        
        }

        [HttpGet("{id:int:min(1)}", Name="ObterProduto")]

        public ActionResult<Produto> Get(int id) 
        {
            var produto = _repository.GetProdutosID(id);
           
            if (produto == null)
            {
                _logger.LogWarning($"Categoria com id= {id} não encontrada...");
                return NotFound($"Categoria com id= {id} não encontrada...");
            }
            return Ok(produto);

        }
        [HttpPost]
        public ActionResult Post(Produto produto) 
        {
          if (produto is null)
          {
            _logger.LogWarning($"Dados inválidos...");
             return BadRequest("Dados inválidos");
          }
          _repository.Create(produto);
          return Ok(produto);
            
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Produto produto)
        {
           if(id != produto.ProdutoId) 
           {
             _logger.LogWarning($"Dados inválidos...");
              return BadRequest("Dados inválidos");
            }
           _repository.Update(produto);
            return Ok(produto);
            

        }
        [HttpDelete("{id:int}")]

        public ActionResult Delete(int id) 
        {
            var prod = _repository.GetProdutosID(id);

            if(prod is null) 
            {
              _logger.LogWarning($"Categoria com id={id} não encontrada...");
              return NotFound($"Categoria com id={id} não encontrada...");
            }

            var prodExcluido = _repository.Delete(id);
            return Ok(prodExcluido);
        
        }

    }
}
