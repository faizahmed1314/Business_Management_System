using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace WebApplication1.Models.ViewModels.Stock
{
    public class StockVm
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        [Display(Name = "Re-Order Level")]
        public int ReOrderLevel { get; set; }
        public string Description { get; set; }
        public byte[] File { get; set; }
        public string FileName { get; set; }
        public string Category { get; set; }
        public int StockIn { get; set; }
        public int StockOut { get; set; }
        public int? ClosingBalance { get; set; }
        public int? OpeningBalance { get; set; }
        
        public DateTime ExpireDate { get; set; }

        //public int OpeningBalance()
        //{
        //    int result = 0;
        //    return result += this.StockIn;
        //}
        //public int ClosingBalance()
        //{
        //    int result = 0;
        //    return result = this.StockIn-this.StockOut;
        //}


    }
}