using APIcatalogo.Models;
using System.Reflection;
using System.Runtime.InteropServices;

namespace APIcatalogo.Repositories
{

    //interface permite varias implementacoes diferentes...
    public interface ICategoriaRepository
    {
        IEnumerable<Categoria> GetCategorias();
        
        Categoria GetCategoriaID(int id);
        
        Categoria Create(Categoria categoria);
        
        Categoria Update(Categoria categoria);
        
        Categoria Delete(int id);
    }
}
