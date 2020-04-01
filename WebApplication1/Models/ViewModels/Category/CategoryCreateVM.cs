using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models.ViewModels.Category
{
    public class CategoryCreateVm
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("Item Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Item Code")]
        public string Code { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}