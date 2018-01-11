using FShop.DB.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fshop.Models
{
    public class Cart
    {
        public int UId { get; set; }
        public List<CartItem> Check { get; set; }
        public Cart()
        {
            Check = new List<CartItem>();
        }
        public double Cost
        {
            get
            {
                double cost = 0;
                foreach(CartItem item in Check)
                {
                    cost += item.Cost;
                }
                return cost;
            }
        }
    }
}