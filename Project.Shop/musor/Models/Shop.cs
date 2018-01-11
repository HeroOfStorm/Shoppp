using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fshop.Models
{
    public class Shop
    {
        public int Id { get; set; }
        public string PlaceName { get; set; }
        public double GeoLat { get; set; }
        public double GeoLong { get; set; }
    }
}