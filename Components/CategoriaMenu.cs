using System.Linq;
using Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Components
{
    public class CategoriaMenu: ViewComponent
    {
        private readonly ICategoria _Icategoria;
        public CategoriaMenu(ICategoria icategoria)
        {
            _Icategoria = icategoria;
        }

        public IViewComponentResult Invoke()
        {
            var categorias = _Icategoria.Categorias.OrderBy(c => c.CategoriaNome);
            return View(categorias);            
        }
    }
}