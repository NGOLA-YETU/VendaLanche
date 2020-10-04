using Interfaces;
using Microsoft.AspNetCore.Mvc;
using ViewModels;

namespace VendaLanche.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILanche _ilanche;

        public HomeController(ILanche ilanche)
        {
            _ilanche = ilanche;
        }
        public IActionResult Index()
        {
            var homeVieModel = new HomeViewModel{
                LPreferidos = _ilanche.Preferidos
            };
            return View(homeVieModel);
        }
    }
}
