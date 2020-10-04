using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Models;
using ViewModels;

namespace Components
{
    public class CarrinhoCompraResumo: ViewComponent
    {
        private readonly CarrinhoCompra _carrinhocompra;

        public CarrinhoCompraResumo(CarrinhoCompra carrinhocompra)
        {
            _carrinhocompra = carrinhocompra;
        }

        public IViewComponentResult Invoke()
        {
            // var itens =_carrinhocompra.GetCarrinhoCompraItems();
            var itens = new List <CarrinhoCompraItem>(){new CarrinhoCompraItem(), new CarrinhoCompraItem()};
            _carrinhocompra.CarrinhoCompraItens = itens;

            var CarrinhoCompraVm = new CarrinhoCompraViewModel
            {
                CarrinhoCompra = _carrinhocompra,
                CarrinhoCompraTotal = _carrinhocompra.GetCarrinhoCompraTotal()
            };

            return View(CarrinhoCompraVm);
        }
    }
}