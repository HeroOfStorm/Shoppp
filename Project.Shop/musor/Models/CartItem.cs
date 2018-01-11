using FShop.DB.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Fshop.Models
{
    public class CartItem
    {
        public Product product { get; set; }
        [Required]
        public int Count { get; set; }
        public double Cost { get
            {
                return (double)product.Price * Count;
            } }
    }
}