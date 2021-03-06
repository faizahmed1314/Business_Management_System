﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        [Display(Name ="Re-Order Level")]
        public int ReOrderLevel { get; set; }
        public string Description { get; set; }
        public byte[] File { get; set; }
        public string FileName { get; set; }
        public int? Quantity { get; set; }


        [NotMapped]
        public HttpPostedFileBase UploadFile { get; set; }
        [Display(Name ="Category")]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        [NotMapped]
        public List<SelectListItem> CategoryLookUp { get; set; }

        
        

    }
}