using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VendaLanche.Models
{
    public class Categoria
    {
        public int CategoriaId { get; set; }
        [Required]
        [StringLength(100)]
        public string CategoriaNome { get; set; }
        [Required]
        [StringLength(100)]
        public string CategoriaDescricao { get; set; }

        public List<Lanche> Lanches{get; set;}
    }
}