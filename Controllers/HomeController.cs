using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSiteAdminPanel.Models;

namespace WebSiteAdminPanel.Controllers
{
    public class HomeController : Controller
    {
        private AdminPanelDatabase db = new AdminPanelDatabase();
        public ActionResult Index()
        {
            ViewBag.Site=db.Site.SingleOrDefault();
            ViewBag.Hizmetler=db.Hizmet.ToList().OrderByDescending(x=>x.HizmetId);
            return View();
        }
        public ActionResult SliderPartial()
        {
            ViewBag.Site = db.Site.SingleOrDefault();
            return View(db.Slider.ToList().OrderByDescending(x=>x.SliderId));
        }
        public ActionResult HizmetPartial()
        {
            ViewBag.Site = db.Site.SingleOrDefault();
            return View(db.Hizmet.ToList().OrderByDescending(a=>a.HizmetId));
        }
        public ActionResult Hakkimizda()
        {
            ViewBag.Site = db.Site.SingleOrDefault();
            return View(db.Hakkimizda.SingleOrDefault());
        }
        public ActionResult Hizmetlerimiz()
        {
            ViewBag.Site = db.Site.SingleOrDefault();
            return View(db.Hizmet.ToList().OrderByDescending(x=>x.HizmetId));
        }
        public ActionResult Iletisim()
        {
            ViewBag.Site = db.Site.SingleOrDefault();
            return View(db.Iletisim.SingleOrDefault());
        }
        public ActionResult Blog()
        {
            ViewBag.Site = db.Site.SingleOrDefault();
            return View(db.Blog.Include("Kategori").ToList().OrderByDescending(z=>z.BlogId));
        }
        public ActionResult BlogKategori(int id)
        {
            ViewBag.Site = db.Site.SingleOrDefault();
            var b = db.Blog.Include("Kategori").Where(x => x.Kategori.KategoriId == id).ToList();
            return  View(b);
        }
        public ActionResult BlogDetay(int id)
        {
            ViewBag.Site = db.Site.SingleOrDefault();
            var blog=db.Blog.Include("Kategori").Where(x=>x.BlogId==id).SingleOrDefault();
            return View(blog);
        }
        public ActionResult BlogKategoriPartial()
        {
            ViewBag.Site = db.Site.SingleOrDefault();
            return PartialView(db.Kategori.ToList().OrderBy(z => z.KategoriAd));
        }
    }
}