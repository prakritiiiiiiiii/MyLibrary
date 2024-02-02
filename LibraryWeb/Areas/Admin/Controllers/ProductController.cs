using Library.DataAccess.Data;
using Library.DataAccess.Repository.IRepository;
using Library.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        public async Task<IActionResult> Index()
        {

            List<Product> objProductList = await _productRepository.GetAllAsync();
            //IEnumerable<SelectListItem> categorylist = objProductList.Select(u => new SelectListItem
            //{
            //    Text = u.Title,
            //    Value = u.Id.ToString()
            //});

            return View(objProductList);

        }



        [HttpGet]
       public async Task<IActionResult> Create()
        {
            var vm = new ProductVm();
            vm.CategoryList = await _categoryRepo.GetAllAsync();
           return View(vm);
        }



        [HttpPost]
        public async Task<IActionResult> Create(ProductVm vmObj)
        {
            vmObj.CategoryList = await _categoryRepo.GetAllAsync();

            if (ModelState.IsValid)
            {
                //in case of failure, use view model as parameter, convert it to product and pass object to Add method.
                _productRepository.Add(vmObj.Product);
                _productRepository.Save();
                TempData["success"] = "Product created successfully.";
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }

        }



        [HttpGet]
        public IActionResult Edit(int id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }
            Product productFromDb = _productRepository.Get(u => u.Id == id);
            
            if (productFromDb == null)
            {
                return NotFound();
            }
            return View(productFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Product obj)
        {
            if (ModelState.IsValid)
            {

                _productRepository.Update(obj);
                _productRepository.Save();
                TempData["success"] = "Product updated successfully.";
                return RedirectToAction("Index");
            }
            return View();
        }



        [HttpGet]
        public IActionResult Delete(int id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }
            Product productFromDb = _productRepository.Get(u => u.Id == id);

            if (productFromDb == null)
            {
                return NotFound();
            }
            return View(productFromDb);
        }

        [HttpPost, ActionName("Delete")]

        public IActionResult DeletePOST(int id)
        {
            Product obj = _productRepository.Get(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }


            _productRepository.Remove(obj);
            _productRepository.Save();
            TempData["success"] = "Product deleted successfully.";
            return RedirectToAction("Index");

        }







    }



}
