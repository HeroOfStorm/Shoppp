using Shop.DataLayer.DB;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        int pagesize = 5;
        ShopContext context;
        static List<BusinessGood> BusinessGoods;
        static BusinessGood CurrentGood;
        public AdminController()
        {
            context = new ShopContext();
            CurrentGood = new BusinessGood();
            if (BusinessGoods == null)
            {
                BusinessGoods = new List<BusinessGood>();
                BusinessGood.Autofill(BusinessGoods);
            }
        }
        public ActionResult Index(int id = 1)
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
            return View(model);
        }
        public PartialViewResult GetTableGoods(int id = 1)
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
        public ActionResult Edit(int id=1)
        {
            CurrentGood = BusinessGoods.FirstOrDefault(x => x.GoodId == id);
            var model = CurrentGood;
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(BusinessGood a)
        {
            if (ModelState.IsValid)
            {
                int index = BusinessGoods
                    .IndexOf(BusinessGoods.FirstOrDefault(x => x.GoodId == a.GoodId));
                BusinessGoods[index] = a;
                BusinessGood.AddOrUpdate(a);
                return RedirectToAction("Index"/*,new { id = (int)Session["page"]}*/);
            }
            else
                return View(a);
        }
        public ActionResult Add()
        {
            return View(new BusinessGood());
        }
        [HttpPost]
        public ActionResult Add(BusinessGood a)
        {
            if (ModelState.IsValid)
            {
                BusinessGoods.Add(a);
                BusinessGood.AddOrUpdate(a);
                return RedirectToAction("Index"/*,new { id = (int)Session["page"]}*/);
            }
            else
                return View(a);
        }
        [HttpGet]
        public ActionResult Remove(int id)
        {
            BusinessGood.Remove(BusinessGoods.FirstOrDefault(x => x.GoodId == id));
            BusinessGoods.Remove(BusinessGoods.FirstOrDefault(x => x.GoodId == id));
            return RedirectToAction("GetTableGoods");
        }
        //[HttpPost]
        //public ActionResult Upload(HttpPostedFileBase fileUpload)
        //{

        //    string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Uploaded\\");
        //    string filename = Path.GetFileName(fileUpload.FileName);
        //    if (filename != null)
        //    {
        //        fileUpload.SaveAs(Path.Combine(path, filename));
        //        CurrentGood.PhotoPath = "Uploaded\\" + filename;
        //    }

        //    return RedirectToAction("Index");
        //}
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            context.Dispose();
        }
    }
}