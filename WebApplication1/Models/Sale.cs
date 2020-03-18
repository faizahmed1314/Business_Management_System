using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Models
{
    public class Sale
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public virtual Customer Customer { get; set; }
        public int CustomerId { get; set; }

        public double GrandTotalValue { get; set; }
        public List<SaleDetails> SaleDetailses { get; set; }

        [NotMapped]
        public List<SelectListItem> CustomerLookup { get; set; }
        [NotMapped]
        public List<SelectListItem> ProductLookup { get; set; }

        [NotMapped]
        public virtual Product Product { get; set; }
        [NotMapped]
        public int ProductId { get; set; }




    }
}