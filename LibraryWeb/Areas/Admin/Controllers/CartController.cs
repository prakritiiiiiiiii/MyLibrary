using Microsoft.AspNetCore.Mvc;

namespace LibraryWeb.Areas.Admin.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
