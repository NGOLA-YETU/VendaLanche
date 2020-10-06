using System;
using System.Collections.Generic;
using System.Linq;
using Interfaces;
using Microsoft.AspNetCore.Mvc;
using VendaLanche.Models;
using VendaLanche.ViewModels;

namespace Controllers
{
    public class LancheController: Controller
    {
        private readonly ILanche _lanche;
        private readonly ICategoria _categoria;

        public LancheController(ILanche ilanche, ICategoria icategoria)
        {
            _lanche = ilanche;
            _categoria = icategoria;
        }

        public IActionResult List(string categoria)
        {
            string _categoria = categoria;
            IEnumerable <Lanche> lanches;
            string categoriaAtual = string.Empty;
           if(string.IsNullOrEmpty(categoria))
           {
               lanches = _lanche.Lanches.OrderBy(l => l.LancheId);
               categoria = "Todos os lanches";
           }
           else
            {
                if(string.Equals("Fast-Food", _categoria, StringComparison.OrdinalIgnoreCase))
                 {
                     lanches = _lanche.Lanches.Where(l => l.Categoria
                     .CategoriaNome.Equals("Fast-Food"))
                     .OrderBy(l => l.LancheNome);
                 }
                 else
                 {
                    lanches = _lanche.Lanches.Where(l => l.Categoria
                    .CategoriaNome.Equals("Kakes"))
                    .OrderBy(l => l.LancheNome); 
                 }
                 categoriaAtual = _categoria;
           }




            var _LancheListViewModel = new LancheListViewModel
            {
                Lanches = lanches,
                CategoriaAtual = categoriaAtual
            };
            return View(_LancheListViewModel);
        }
    }
}