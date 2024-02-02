using System.ComponentModel.DataAnnotations;

namespace LibraryWeb.Areas.Admin.ViewModel
{
    public class CategoryIndexVm
    {
        [Display(Name = "Name")]
        public string Name { get; set; }
        public List<CategoryInfoVm> Categories { get; set; }
    }
    public class CategoryInfoVm
    {
        public string Name { get; set; }
        public int DisplayOrder { get; set; }
    }
}
