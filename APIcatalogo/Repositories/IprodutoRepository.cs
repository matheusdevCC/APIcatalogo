using APIcatalogo.Models;

namespace APIcatalogo.Repositories
{
    public interface IprodutoRepository
    {
        IEnumerable<Produto> GetProdutos();

        Produto GetProdutosID(int id);

        Produto Create(Produto produto);

        Produto Update(Produto produto);

        Produto Delete(int id);
    }
}
