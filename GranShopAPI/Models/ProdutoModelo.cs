using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace GranShopAPI.Models
{
    [Table("Produto")]
    public class Produto
    {
        [Key]
        public int Id { get; set; }

        // public int CategoriaId {get; set;}

        [ForeignKey("CategoriaId")]
        public Categoria Categoria { get; set; }
        public int CategoriaId { get; set; }

        [Required]
        [MaxLength(200)]
        public string Nome { get; set; }

        [Required]
        [MaxLength(500)]
        public string Descricao { get; set; }

        [Required]
        [MaxLength(100)]
        public int estoque { get; set; }

        [Required]
        [MaxLength(50)]
        public decimal valorCusto { get; set; }

        [Required]
        [MaxLength(50)]
        public decimal valorVenda { get; set; }

        [Required]
        public bool destaque { get; set; }
    }
}