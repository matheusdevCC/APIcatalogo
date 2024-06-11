﻿using APIcatalogo.Context;
using APIcatalogo.Models;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIcatalogo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriasController : Controller
    {
        private readonly AppDbContext _context;

        public CategoriasController(AppDbContext context)
        {
            _context = context;
        }
  
        [HttpGet]
        public ActionResult<IEnumerable<Categoria>> get()
        {
            var categorias = _context.Categorias.ToList();
            if (categorias is null)
            {
                return NotFound("Produtos não encontrados...");
            }
            return categorias;
        }

        [HttpGet("{id:int}", Name = "ObterCategoria")]
        public ActionResult<Categoria> getId(int id)
        {
            var categorias = _context.Categorias.FirstOrDefault(p => p.CategoriaId == id);
            if (categorias is null)
            {
                return NotFound("Produto não encontrado!");
            }
            return categorias;

        }
        [HttpPost]
        public ActionResult Post(Categoria categoria) 
        {
         if(categoria is null) 
         {
          return BadRequest();
         }
            _context.Categorias.Add(categoria);
            _context.SaveChanges();

            return new CreatedAtRouteResult("ObterCategoria", new { id = categoria.CategoriaId }, categoria);    
        }
        [HttpPut("{id}")]
        public ActionResult Put(int id, Categoria categoria) 
        {
         if(id != categoria.CategoriaId) 
            {
                return BadRequest();
            }
         _context.Entry(categoria).State=EntityState.Modified;
            _context.SaveChanges();
            return Ok(categoria);
        
        }
        [HttpDelete("{id}")]
        public ActionResult Delete(int id) 
        {
            var categoria = _context.Categorias.FirstOrDefault(x=> x.CategoriaId==id);
            if(categoria == null) 
            {
                return NotFound("Categoria não encontrada em nosso sistema!");
            
            }
            _context.Categorias.Remove(categoria);
            _context.SaveChanges();
            return Ok(categoria);
        
        }

        [HttpGet("produtos")]
        public ActionResult<IEnumerable<Categoria>> GetCategoriaProdutos() 
        {
         return _context.Categorias.Include(p=>p.Produtos).ToList();
        
        }

    }
}
