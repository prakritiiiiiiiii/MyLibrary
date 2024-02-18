using Library.DataAccess.Data;
using Library.DataAccess.Repository.IRepository;
using Library.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NuGet.Protocol.Plugins;
using System.Collections.Generic;

namespace LibraryWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepo;

        public ProductController(IProductRepository productRepository,
            ICategoryRepository categoryRepo)
        {
            _productRepository = productRepository;
            _categoryRepo = categoryRepo;
        }
        public IActionResult Index(String searchstring ,long categoryid)
        {
            ViewBag.categorylist = _categoryRepo.GetAll().ToList();
            ViewBag.Searchstring = searchstring;
            List<Product> obj = _productRepository.GetAll().ToList();
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
                CategoryList = _categoryRepo.GetAll().ToList(),
                Product = new Product()
            };
            return View(productVM);
        }

        [HttpPost]

        public IActionResult Create(ProductVm vm)
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

            return View(vm1);
        }


        [HttpPost]
        public IActionResult Edit(ProductVm obj2)
        {
            //if (ModelState.IsValid)
            //{

            //    _productRepository.Update(obj2.Product);
            //    _productRepository.Save();
            //    TempData["success"] = "Updated successfully";
            //    return RedirectToAction("Index");
            //}

            //obj2.CategoryList = _categoryRepo.GetAll().ToList();
            //return View(obj2);
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
                _productRepository.Remove(productobj);
                _productRepository.Save();
                TempData["success"] = "Deleted successfully";
                return RedirectToAction("Index");
            }
        }
    }
}
