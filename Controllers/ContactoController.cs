using Microsoft.AspNetCore.Mvc;

namespace Controllers
{
    public class ContactoController: Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}