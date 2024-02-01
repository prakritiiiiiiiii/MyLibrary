using Library.DataAccess.Data;
using Library.DataAccess.Repository.IRepository;
using Library.Models;
using Microsoft.AspNetCore.Mvc;

namespace LibraryWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {

        private readonly ICategoryRepository _unitOfWork;
        public CategoryController(ICategoryRepository unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<Category> objCategoryList = _unitOfWork.GetAll().ToList();
            return View(objCategoryList);
        }




        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Name.");
            }

            if (ModelState.IsValid)
            {
                _unitOfWork.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Category created successfully.";
                return RedirectToAction("Index");
            }

            return View();
        }



        [HttpGet]
        public IActionResult Edit(int id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category categoryFromDb = _unitOfWork.Get(u => u.Id == id);

            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Name.");
            }

            if (ModelState.IsValid)
            {
                _unitOfWork.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Category updated successfully.";
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
            Category categoryFromDb = _unitOfWork.Get(u => u.Id == id);

            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }

        [HttpPost, ActionName("Delete")]

        public IActionResult DeletePOST(int id)
        {
            Category obj = _unitOfWork.Get(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }


            _unitOfWork.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Category deleted successfully.";
            return RedirectToAction("Index");

        }







    }



}
