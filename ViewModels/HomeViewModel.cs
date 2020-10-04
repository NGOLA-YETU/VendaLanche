using System.Collections.Generic;
using VendaLanche.Models;

namespace ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable <Lanche> LPreferidos {get; set;}
    }
}