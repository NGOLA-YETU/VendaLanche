using Interfaces;
using Microsoft.AspNetCore.Mvc;
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

        public IActionResult List()
        {
            ViewBag.Lanche = "Lanches";
            ViewData["Categoria"] = "Categoria";

           /*  var lanches = _lanche.Lanches;
            return View(lanches); */

            var _LancheListViewModel = new LancheListViewModel();
            _LancheListViewModel.Lanches = _lanche.Lanches;
            _LancheListViewModel.CategoriaAtual = "Categoria Atual";
            return View(_LancheListViewModel);
        }
    }
}