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

        private readonly IProductRepository _unitOfWork;
        public ProductController(IProductRepository unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {

            List<Product> objProductList = _unitOfWork.GetAll().ToList();
            //IEnumerable<SelectListItem> CategoryList = _unitOfWork.GetAll().Select(u => new SelectListItem
            //{
            //    Text = u.Name,
            //    Value = u.Id.ToString()
            //});

            return View(objProductList);

        }




       public IActionResult Create()
        {
            ProductViewModel model = new ProductViewModel
            {
                 
                    CategoryList = _unitOfWork.GetAll().Select(u => new SelectListItem
                    {

                        Value = u.Id.ToString(),
                    }),
                    Product = new Product()
                
            };
           return View(model);
       }



        [HttpPost]
        public IActionResult Create(Product obj)
        {

            if (ModelState.IsValid)
            {         
                //in case of failure, use view model as parameter, convert it to product and pass object to Add method.
                _unitOfWork.Add(obj);
                _unitOfWork.Save();
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
            Product productFromDb = _unitOfWork.Get(u => u.Id == id);
            
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

                _unitOfWork.Update(obj);
                _unitOfWork.Save();
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
            Product productFromDb = _unitOfWork.Get(u => u.Id == id);

            if (productFromDb == null)
            {
                return NotFound();
            }
            return View(productFromDb);
        }

        [HttpPost, ActionName("Delete")]

        public IActionResult DeletePOST(int id)
        {
            Product obj = _unitOfWork.Get(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }


            _unitOfWork.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Product deleted successfully.";
            return RedirectToAction("Index");

        }







    }



}
