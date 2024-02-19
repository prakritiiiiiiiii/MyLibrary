using Microsoft.AspNetCore.Mvc.Rendering;

namespace Library.Models
{
    public class ProductVm
    {

          

        public Product Product { get; set; }
        //public int  CategoryId { get; set; }
        public List<Category> CategoryList { get; set; }

        public SelectList getCategories() => new SelectList(CategoryList,nameof(Category.Id), nameof(Category.Name), Product.CategoryId);
        public Category Category { get; set; }

        //public IEnumerable<SelectListItem> CategoryList { get; set; }

    }
}
