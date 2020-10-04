using System;
using System.Collections.Generic;
using System.Linq;
using DataBase;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using VendaLanche.Models;

namespace Models
{
    public class CarrinhoCompra
    {
        private readonly LancheDbContext _context;

        public CarrinhoCompra(LancheDbContext context)
        {
            _context = context;
        }
        public string CarrinhoCompraId{get; set;}
        public List <CarrinhoCompraItem> CarrinhoCompraItens{get; set;}

     #region CarrinhoCompra
    public static CarrinhoCompra GetCarrinho(IServiceProvider services)
    {
        //definir uma sessão acessando o contexto atual(registrar em IserviceContext)
        ISession session = services.GetRequiredService <IHttpContextAccessor>()?
        .HttpContext.Session;

        //obter um serviço do tipo do nosso contexto
        var context = services.GetService <LancheDbContext>();

        //obter ou gerar o Id do carrinho
        string carrinhoId = session.GetString("CarrinhoId") ?? Guid.NewGuid().ToString();

        //atribuir o Id do carrinho a sessão
        session.SetString("CarrinhoId", carrinhoId);

        //Retornar o carrinho com o contexto atual e o id atribuido ou obtido
        return new CarrinhoCompra(context)
        {
            CarrinhoCompraId = carrinhoId
        };
    }

      #endregion
    
     #region AdicionarAoCarrinho
     public void AdicionarAoCarrinho(Lanche lanche, int quantidade)
     {
         var carrinhoCompraItem = _context.CarrinhoCompraItems.SingleOrDefault(
             s => s.Lanche.LancheId == lanche.LancheId && s.CarrinhoCompraId == CarrinhoCompraId
         );

         if (carrinhoCompraItem == null){
             carrinhoCompraItem = new CarrinhoCompraItem{
                 CarrinhoCompraId = CarrinhoCompraId,
                 Lanche = lanche,
                 Quantidade = 1
             };
             _context.CarrinhoCompraItems.Add(carrinhoCompraItem);
         }
         else{
             carrinhoCompraItem.Quantidade ++;
         }
         _context.SaveChanges();
     }
     #endregion
     
     #region RemoverDoCarrinho
     public int RemoverDoCarrinho(Lanche lanche)
     {
         var carrinhoCompraItem = _context.CarrinhoCompraItems.SingleOrDefault(
             s => s.Lanche.LancheId == lanche.LancheId && s.CarrinhoCompraId == CarrinhoCompraId
         );

         var quantidadeLocal = 0;

         if (carrinhoCompraItem != null){
             if(carrinhoCompraItem.Quantidade >1){
                 carrinhoCompraItem.Quantidade --;
                 quantidadeLocal = carrinhoCompraItem.Quantidade;
             }
             else{
                 _context.CarrinhoCompraItems.Remove(carrinhoCompraItem);
             }
         }
         _context.SaveChanges();
         return quantidadeLocal;
     }
     #endregion

     #region ListarCarrinhoCompraItem
     public List <CarrinhoCompraItem> GetCarrinhoCompraItems()
     {
         return CarrinhoCompraItens ??(CarrinhoCompraItens = _context.CarrinhoCompraItems
         .Where(c => c.CarrinhoCompraId == CarrinhoCompraId)
         .Include(s => s.Lanche)
         .ToList()
         );
         
     }
     #endregion
   
     #region LimparCarrinho
     public void LimparCarrinho()
     {
         var carrinhoItens = _context.CarrinhoCompraItems.Where
         (carrinho => carrinho.CarrinhoCompraId == CarrinhoCompraId); 

         _context.CarrinhoCompraItems.RemoveRange(carrinhoItens);
         _context.SaveChanges();

     }
     #endregion
    
    #region GetCarrinhoCompraTotal
    public decimal GetCarrinhoCompraTotal()
    {
        var total = _context.CarrinhoCompraItems.Where(c => c.CarrinhoCompraId == CarrinhoCompraId)
        .Select(c => c.Lanche.Preco * c.Quantidade).Sum();
        return total;
    }
    #endregion
    }
}