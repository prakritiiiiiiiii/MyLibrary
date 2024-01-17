using LibraryWeb.Data;
using LibraryWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace LibraryWeb.Controllers
{
    public class CategoryController : Controller
    {
     
           private readonly ApplicationDbContext _db;
           public CategoryController(ApplicationDbContext db)
           {
            _db = db;
           }
            public IActionResult Index()
            {
             List<Category> objCategoryList = _db.Categories.ToList();  
              return View(objCategoryList);
            }

            public IActionResult Create()
            {
                return View();
            }

            [HttpPost]
            public IActionResult Create(Category obj)
            {

            if(ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
              
                return View();
            }
    }
}
