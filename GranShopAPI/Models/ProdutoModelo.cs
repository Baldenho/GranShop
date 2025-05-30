using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace GranShopAPI.Models
{
    [Table("Produto")]
    public class Produto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int CategoriaId { get; set; }
        [ForeignKey("CategoriaId")]
        public Categoria Categoria { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        [MaxLength(500)]
        public string Descricao { get; set; }

        [Required]
        public int Estoque { get; set; }

        [Required]
        public decimal ValorCusto { get; set; }

        [Required]
        public decimal ValorVenda { get; set; }

        [Required]
        public bool Destaque { get; set; }
    }
}