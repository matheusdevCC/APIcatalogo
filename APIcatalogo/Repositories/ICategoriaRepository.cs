using APIcatalogo.Models;
using System.Reflection;
using System.Runtime.InteropServices;

namespace APIcatalogo.Repositories
{

    //interface permite varias implementacoes diferentes...
    public interface ICategoriaRepository
    {
        IEnumerable<Categoria> GetCategorias();
        
        Categoria GetCateogria(int id);
        
        Categoria Create(Categoria categoria);
        
        Categoria Update(int id, Categoria categoria);
        
        Categoria Delete(int id);
    }
}
