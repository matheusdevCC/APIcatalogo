using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIcatalogo.Migrations
{
    /// <inheritdoc />
    public partial class PopulaCategorias : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("Insert into Categorias(Nome, ImagemUrl) Values('Bebidas', 'bebidas.jpg')");
            mb.Sql("Insert into Categorias(Nome, ImagemUrl) Values('Lanches', 'lanches.jpg')");
            mb.Sql("Insert into Categorias(Nome, ImagemUrl) Values('Sobremesas', 'sobremesas.jpg')");

            //produtos

            mb.Sql("Insert into Produtos(Nome,Descricao,Preco,ImagemUrl,Estoque,DataCadastro,CategoriaID)" +
                "Values('Coca-Cola','Refrigerante lata 350ml',5.45,'cocacola.png',50,now(),1");

            mb.Sql("Insert into Produtos(Nome,Descricao,Preco,ImagemUrl,Estoque,DataCadastro,CategoriaID)" +
                "Values('X-burguer','X-burguer Completo',15.00,'burguer.png',10,now(),2");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder mb)
        {

        }
    }
}
