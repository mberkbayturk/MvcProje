using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProje.Controllers
{
    public class StatisticsController : Controller
    {
        Context context = new Context();
        public ActionResult Index()
        {
            //Toplam kategori sayısı
            var result = context.Categories.Count();
            ViewBag.CategoryCount = result;

            //Yazılım kategorisine ait başlık sayısı
            var result2 = context.Headings.Count(x => x.Category.CategoryID == 21);
            ViewBag.Heading = result2;

            //Adında 'a' harfi geçen yazar sayısı
            var result3 = context.Writers.Count(x => x.WriterName.Contains("a"));
            ViewBag.Writer = result3;

            //En fazla başlığa sahip kategori adı
            var result4 = context.Headings.Max(x => x.Category.CategoryName);
            ViewBag.HeadingMax = result4;

            //Kategori tablosunda durumu true ile false olan kategoriler arasındaki sayısal fark
            var result5 = context.Categories.Count(x => x.CategoryStatus == true);
            var result6 = context.Categories.Count(x => x.CategoryStatus == false);
            ViewBag.Status = (result5 - result6);

            return View();
        }
    }
}