using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace GranShopAPI.Models
{
    [Table("Categoria")]
    public class Categoria
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nome { get; set; }
    }

    [Table("Produto")]
    public class Produto
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Categoria")]
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