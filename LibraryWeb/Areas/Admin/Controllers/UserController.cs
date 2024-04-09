using Microsoft.AspNetCore.Mvc;

namespace LibraryWeb.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
