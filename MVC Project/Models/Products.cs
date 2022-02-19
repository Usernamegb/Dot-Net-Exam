using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _210940320041.Models
{
    public class Products
    {
           
            public int ProductId { get; set; }

            [DataType(DataType.Text)]
            [Required(ErrorMessage ="Product Name is required")]
            [StringLength(50,ErrorMessage ="Product Name cannot exceed {1}")]
            public string ProductName { get; set; }
        
            public decimal Rate { get; set; }


            [DataType(DataType.MultilineText)]
            [Required(ErrorMessage = "Description is required")]
            [StringLength(200, ErrorMessage = "Description cannot exceed {1}")]
            public string Description { get; set; }

            [DataType(DataType.Text)]
            [Required(ErrorMessage = "Category Name is required")]
            [StringLength(50, ErrorMessage = "Category Name cannot exceed {1}")]
            public string CategoryName { get; set; }
    }
}