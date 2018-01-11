using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class GoodViewModel
    {
        public IEnumerable<BusinessGood> GoodsList { get; set; }
        public PageLinkModel PageLinkInfo {get;set;}

    }
}