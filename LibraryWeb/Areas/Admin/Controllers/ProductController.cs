using Library.DataAccess.Data;
using Library.DataAccess.Repository.IRepository;
using Library.Models;
using LibraryWeb.Helper.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using NuGet.Protocol.Plugins;
using System.Collections.Generic;

namespace LibraryWeb.Areas.Admin.Controllers

{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepo;
        private readonly ApplicationDbContext _context;
        private readonly IFileHelper _fileHelper;

        public ProductController(IProductRepository productRepository, ICategoryRepository categoryRepo, ApplicationDbContext context, IFileHelper fileHelper)
        {
            _productRepository = productRepository;
            _categoryRepo = categoryRepo;
            _context = context;
            _fileHelper = fileHelper;
           
        }

        public IActionResult Index(String searchstring ,long categoryid)
        {
            ViewBag.categorylist = _categoryRepo.GetAll();
            ViewBag.Searchstring = searchstring;
            var obj = _productRepository.GetAll();
            if (searchstring != null)
            {
                obj = obj.Where(
                    x => x.Title.Contains(searchstring, StringComparison.OrdinalIgnoreCase)
                    || x.Description.Contains(searchstring, StringComparison.OrdinalIgnoreCase)

                ).ToList();

            }
            if(categoryid != 0)
            {
                obj = obj.Where(x => x.CategoryId == categoryid).ToList();
            }
            return View(obj);
        }


        public IActionResult Create()
        {
            ProductVm productVM = new ProductVm()
            {
                CategoryList = _categoryRepo.GetAll(),
                Product = new Product()
            };
            return View(productVM);
        }
       


        [HttpPost]

        public IActionResult Create(ProductVm vm, IFormFile Image)
        {


            //if (ModelState.IsValid)
            //{
            //    _productRepository.Add(vm.Product);
            //    _productRepository.Save();
            //    TempData["success"] = "Created successfully";
            //    return RedirectToAction("Index");
            //}
            //else
            //{

            //    vm.CategoryList = _categoryRepo.GetAll().ToList();
            //}  
            


            if(Image != null)
            {
                vm.Product.ImageUrl = _fileHelper.SaveFileAndReturnName("images//product", Image);
            }
            _productRepository.Add(vm.Product);
            _productRepository.Save();
            TempData["success"] = "Created successfully";
            return RedirectToAction("Index");


            //return Content($"{vm.Product.Name}{vm.Product.ISBN},{vm.Product.ISBN}{vm.Product.Description}");

        }



        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Product productObj = _productRepository.Get(u => u.Id == id);

            if (productObj == null)
            {
                return NotFound();
            }

            ProductVm vm1 = new ProductVm
            {
                Product = productObj,
                CategoryList = _categoryRepo.GetAll().ToList()
            };
            ViewBag.Img = productObj.ImageUrl;
            return View(vm1);
        }


        [HttpPost]
        public IActionResult Edit(ProductVm obj2,IFormFile Image)
        {
            //if (ModelState.IsValid)
            //{

            //    _productRepository.Update(obj2.Product);
            //    _productRepository.Save();
            //    TempData["success"] = "Updated successfully";
            //    return RedirectToAction("Index");
            //}
            var previous = _context.Set<Product>().Find(obj2.Product.Id);
            if(Image!=null)
            {
                if(previous.ImageUrl != String.Empty)
                {
                    _fileHelper.Delete("images//product", previous.ImageUrl);
                }
                obj2.Product.ImageUrl = _fileHelper.SaveFileAndReturnName("images//product", Image);
            }
            else
            {
                obj2.Product.ImageUrl = previous.ImageUrl;
            }
            //obj2.CategoryList = _categoryRepo.GetAll().ToList();
            //return View(obj2);
            var existingProductEntry = _context.Entry(previous);
            if (existingProductEntry.State == EntityState.Unchanged)
            {
                // Detach the entity if it's currently being tracked
                existingProductEntry.State = EntityState.Detached;
            }
            _productRepository.Update(obj2.Product);
            _productRepository.Save();
            TempData["success"] = "Updated successfully";
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int? id)
        {
            Product productobj = _productRepository.Get(u => u.Id == id);
            if (productobj == null)
            {
                return NotFound();
            }
            else
            {

                _fileHelper.Delete("images//product",productobj.ImageUrl);
                _productRepository.Remove(productobj);
                _productRepository.Save();
                TempData["success"] = "Deleted successfully";
                return RedirectToAction("Index");

            }
        }


    }
}
