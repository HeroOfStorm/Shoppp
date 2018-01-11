using Shop.DataLayer.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Models
{
    public class BusinessGood
    {
        static ShopContext context = new ShopContext();
        public BusinessGood()
        {
            
        }
        [HiddenInput]
        public int GoodId { get; set; }
        [Required]
        [StringLength(100)]
        public string GoodName { get; set; }
        [Column(TypeName = "money")]
        public decimal Price { get; set; }

        [Column(TypeName = "numeric")]
        public decimal GoodCount { get; set; }

        public virtual Category Category { get; set; }

        public virtual Manufacturer Manufacturer { get; set; }
        [Required]
        [StringLength(200)]
        public string PhotoPath { get; set; }
        public static void AddOrUpdate(BusinessGood a)
        {
            ShopContext context = new ShopContext();
            Photo p;
                Good b = context.Good.FirstOrDefault(x => x.GoodId == a.GoodId);

            if (b == null)
            {
                b = new Good();
                b.GoodCount = a.GoodCount;
                b.GoodName = a.GoodName;
                b.Manufacturer = a.Manufacturer;
                b.Price = a.Price;
                b.Category = a.Category;
                context.Good.Add(b);
                context.SaveChanges();

                p = new Photo();
                p.GoodId = context.Good.FirstOrDefault(x => x.GoodName == a.GoodName).GoodId;
                p.PhotoPath = a.PhotoPath;
                context.Photo.Add(p);
                context.SaveChanges();
            }
            else
            {
                b.GoodCount = a.GoodCount;
                b.GoodName = a.GoodName;
                b.Manufacturer = a.Manufacturer;
                b.Price = a.Price;
                b.Category = a.Category;
                p = context.Photo.FirstOrDefault(x => x.GoodId == a.GoodId);
                p.PhotoPath = a.PhotoPath;
                context.SaveChanges();
            }
        }
        
        public static List<BusinessGood> Autofill(List<BusinessGood> BS)
        {
            
                foreach (var i in context.Good)
                {
                BusinessGood tmp = new BusinessGood();

                tmp.GoodId = i.GoodId;
                tmp.GoodName = i.GoodName;
                tmp.Price = i.Price;
                //tmp.Category = i.Category;
                //tmp.Manufacturer = i.Manufacturer;
                tmp.GoodCount = i.GoodCount;
                //tmp.PhotoPath = context.Photo.Find(i.GoodId).PhotoPath;
                 
                BS.Add(tmp);
                }
            
            return BS;
        }
        public static void Remove(BusinessGood a)
        {
            ShopContext context = new ShopContext();
            context.Good.Remove(context.Good.FirstOrDefault(x => x.GoodId == a.GoodId));
            context.Photo.Remove(context.Photo.FirstOrDefault(x => x.GoodId == a.GoodId));
            context.SaveChanges();
        }
        }
}