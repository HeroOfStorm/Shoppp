using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop.DataLayer.DB;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ClientController : Controller
    {
        int pagesize = 3;
        ShopContext context;
        List<BusinessGood> BusinessGoods;
        public ClientController()
        {
            context = new ShopContext();
            BusinessGoods = new List<BusinessGood>();
            BusinessGood.Autofill(BusinessGoods);
        }

        public ActionResult Index(int id=1)
        {
            
            var model = new GoodViewModel
            {
                GoodsList=BusinessGoods.Skip((id - 1) * pagesize).Take(pagesize),
                PageLinkInfo = new PageLinkModel
                {
                    CurrentPage = id,
                    TotalItems = BusinessGoods.Count(),
                    CountPerPage = pagesize
                }
            };
            return View(model);
        }

        public PartialViewResult GoodsCards(int id=1)
        {
            var model = new GoodViewModel
            {
                GoodsList = BusinessGoods.Skip((id - 1) * pagesize).Take(pagesize),
                PageLinkInfo = new PageLinkModel
                {
                    CurrentPage = id,
                    TotalItems = BusinessGoods.Count(),
                    CountPerPage = pagesize
                }
            };
            return PartialView(model);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            context.Dispose();
        }
    }
}