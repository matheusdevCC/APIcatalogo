using APIcatalogo.Validations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace APIcatalogo.Models
{
    [Table(("Produto"))]
    public class Produto : IValidatableObject
    {
        public int ProdutoId { get; set; }
        [Required(ErrorMessage ="O nome é obrigatório")]
        [StringLength(30, ErrorMessage ="O nome deve ter entre 5 a 30 caracteres", MinimumLength = 5)]
        [PrimeiraLetraMaiuscula]
        public string? Nome { get; set; }
        [Required]
        [StringLength(300)]
        public string? Descricao { get; set; }
        [Required]
        [Column(TypeName ="decimal(10,2)")]
        public decimal Preco { get; set; }
        [Required]
        [StringLength(300)]
        public string? ImagemUrl { get; set; }
        public float Estoque { get; set; }
        public DateTime DataCadastro { get; set; }

        public int CategoriaId { get; set; }

        [JsonIgnore]
        public Categoria? Categoria { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if(!string.IsNullOrEmpty(Nome)) 
            {
                var primeira = this.Nome[0].ToString();
                if(primeira!= primeira.ToUpper()) 
                {
                
                yield return new ValidationResult("A primeira letra do produto deve ser maiúscula!",
                    new[] { nameof(this.Nome)});
                }  
            }
        }
    }
}
