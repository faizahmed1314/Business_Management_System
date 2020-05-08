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
        public string Name { get; set; }
        [Required]
        public string Code { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}