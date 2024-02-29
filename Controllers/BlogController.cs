using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using WebSiteAdminPanel.Models;

namespace WebSiteAdminPanel.Controllers
{
    public class BlogController : Controller
    {
        private AdminPanelDatabase db=new AdminPanelDatabase();
        public ActionResult Index()
        {
            ViewBag.Site = db.Site.SingleOrDefault();
            db.Configuration.LazyLoadingEnabled = false;
            return View(db.Blog.Include("Kategori").ToList());
        }
        public ActionResult Create()
        {
            ViewBag.KategoriId = new SelectList(db.Kategori,"KategoriId","KategoriAd");
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Blog blog, HttpPostedFileBase ResimUrl)
        {
            if (ResimUrl!=null)
            {
                WebImage img = new WebImage(ResimUrl.InputStream);
                FileInfo imginfo = new FileInfo(ResimUrl.FileName);

                string blogimgName= ResimUrl.FileName + imginfo.Extension;
                img.Resize(600,400);
                img.Save("~/Uploads/Blog/" + blogimgName);
                blog.ResimUrl = "/Uploads/Blog/"+ blogimgName;

            }
            db.Blog.Add(blog);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int? id)
        {
            if (id==null)
            {
                return HttpNotFound();
            }
            var b = db.Blog.Where(x =>x.BlogId==id).SingleOrDefault();
            if (b==null)
            {
                return HttpNotFound();
            }
            ViewBag.KategoriId = new SelectList(db.Kategori,"KategoriId","KategoriAd",b.KategoriId);
            return View(b);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(int id, Blog blog, HttpPostedFileBase ResimUrl)
        {
            if (ModelState.IsValid)
            {
                var b = db.Blog.Where(x=>x.BlogId==id).SingleOrDefault();
                if (ResimUrl!=null)
                {
                    if (System.IO.File.Exists(Server.MapPath(b.ResimUrl)))
                    {
                        System.IO.File.Delete(Server.MapPath(b.ResimUrl));
                    }
                    WebImage img = new WebImage(ResimUrl.InputStream);
                    FileInfo imginfo = new FileInfo(ResimUrl.FileName);

                    string blogimgName = ResimUrl.FileName + imginfo.Extension;
                    img.Resize(600,400);
                    img.Save("~/Uploads/Blog/"+blogimgName);

                    b.ResimUrl = "/Uploads/Blog/" + blogimgName;
                }
                b.Baslik=blog.Baslik;
                b.Icerik=blog.Icerik;
                b.KategoriId=blog.KategoriId;
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(blog); 
        }
        public ActionResult Delete(int id)
        {
            var b = db.Blog.Find(id);
            if (b==null)
            {
                return HttpNotFound();
            }
            if (System.IO.File.Exists(Server.MapPath(b.ResimUrl)))
            {
                System.IO.File.Delete(Server.MapPath(b.ResimUrl));
            }
            db.Blog.Remove(b);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        
    }

}