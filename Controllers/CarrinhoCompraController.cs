using System.Linq;
using Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models;
using ViewModels;

namespace Controllers
{
    public class CarrinhoCompraController:Controller
    {
        private readonly ILanche _ilanche;
        private readonly CarrinhoCompra _carrinhocompra;

        public CarrinhoCompraController(ILanche ilanche, CarrinhoCompra carrinhoCompra)
        {
            _ilanche = ilanche;
            _carrinhocompra = carrinhoCompra;
        }

        public IActionResult Index(){
           var itens = _carrinhocompra.GetCarrinhoCompraItems();
           _carrinhocompra.CarrinhoCompraItens = itens;

           var carrinhoCompraViewModel = new CarrinhoCompraViewModel
           {
               CarrinhoCompra = _carrinhocompra,
               CarrinhoCompraTotal = _carrinhocompra.GetCarrinhoCompraTotal()
           };
           return View(carrinhoCompraViewModel);

        }

        public RedirectToActionResult AdicionarAoCarrinhoCompra(int lancheId)
        {
            var lacnheSelecionado = _ilanche.Lanches.FirstOrDefault( p => p.LancheId == lancheId);
            if(lacnheSelecionado != null){
                _carrinhocompra.AdicionarAoCarrinho(lacnheSelecionado, 1);
            }
            return RedirectToAction("Index");
        }

        public IActionResult RemoverItemDoCarrinhoCompra( int lancheId)
        {
            var lacnheSelecionado = _ilanche.Lanches.FirstOrDefault(p => p.LancheId == lancheId);
            if(lacnheSelecionado != null){
                _carrinhocompra.RemoverDoCarrinho(lacnheSelecionado);
            }
            return RedirectToAction("Index");
        }
        
    }
}