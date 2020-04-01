using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication1.Models.ViewModels.Customer
{
    public class CustomerEditVm
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Code field is required!")]
        public string Code { get; set; }
        [Required(ErrorMessage = "Name field is required!")]

        public string Name { get; set; }
        public string Address { get; set; }
        [Required(ErrorMessage = "Email field is required!")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public string ContactNumber { get; set; }
        public int LoyaltyPoint { get; set; }
        public byte[] File { get; set; }
        public string FileName { get; set; }
        [NotMapped]
        public HttpPostedFileBase UploadFile { get; set; }
    }
}