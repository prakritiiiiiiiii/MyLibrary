using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Security.Principal;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Library.Models
{
     public class ProductViewModel
    {
          

        public Product Product { get; set; } 
        public IEnumerable<SelectListItem> CategoryList { get; set; }
        public Category Category { get; set; }
        //public IEnumerable<SelectListItem> CategoryList { get; set; }

    }
}
