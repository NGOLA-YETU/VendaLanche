using System.Collections.Generic;
using VendaLanche.Models;

namespace VendaLanche.ViewModels
{
    public class LancheListViewModel
    {
        public IEnumerable <Lanche> Lanches{get; set;}
        public string CategoriaAtual {get; set;}
    }
}