using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filter)
        {
            //     filter.Add(new AuthorizeAttribute());
            filter.Add(new HandleErrorAttribute());
        }
    }
}