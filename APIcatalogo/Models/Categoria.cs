using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIcatalogo.Models
{
    [Table("Categorias")]
    public class Categoria
    {
        public Categoria()
        {
            Produtos = new Collection<Produto>();
        }
        [Key]
        public int CategoriaId { get; set; }
        [Required]
        [StringLength(50)]
        public string? nome { get; set; }
        [Required]
        [StringLength(250)]
        public string? ImagemUrl { get; set; }

        public ICollection<Produto>? Produtos { get; set; }
    }
}
