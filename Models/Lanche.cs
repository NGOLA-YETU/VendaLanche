using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VendaLanche.Models
{
    public class Lanche
    {
        public int LancheId { get; set; }
        [Required]
        [StringLength(100)]
        public string LancheNome { get; set; }
        [Required]
        [StringLength(100)]
        public string DescCurta { get; set; }
        [Required]
        [StringLength(200)]
        public string DescLonga { get; set; }
        [Required]
        [Column(TypeName = "decimal(18, 6)")]
        public decimal Preco { get; set; }
        [Required]
        [StringLength(200)]
        public string ImagemUrl { get; set; } 
        [Required]
        [StringLength(200)] 
        public string ImagemThumbnailUrl { get; set; }
        public bool Preferido { get; set; }
        public bool EmEstoque { get; set; }
        public int CategoriaId { get; set; }

        public virtual Categoria Categoria{get; set;}

    }
}