using Library.DataAccess.Repository;
using Library.DataAccess.Repository.IRepository;
using Library.Models;
using LibraryWeb.Areas.Admin.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LibraryWeb.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;

        public HomeController(ILogger<HomeController> logger, IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            _logger = logger;
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }
       
        public IActionResult Index()
        
        {

            DashboardVm Dvm = new DashboardVm
            {
                CategoryCount = _categoryRepository.GetAll().Count(),
                ProductCount = _productRepository.GetAll().Count()
            };

            return View(Dvm);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}