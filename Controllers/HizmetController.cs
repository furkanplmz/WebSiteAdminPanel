using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using WebSiteAdminPanel.Models;

namespace WebSiteAdminPanel.Controllers
{
    public class HizmetController : Controller
    {
        private AdminPanelDatabase db= new AdminPanelDatabase();
        public ActionResult Index()
        {
            ViewBag.Site = db.Site.SingleOrDefault();
            return View(db.Hizmet.ToList());
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Hizmet hizmet, HttpPostedFileBase ResimUrl)
        {
            if (ModelState.IsValid)
            {
                if (ResimUrl !=null)
                {
                    WebImage img = new WebImage(ResimUrl.InputStream);
                    FileInfo imginfo=new FileInfo(ResimUrl.FileName);

                    string logoname = ResimUrl.FileName + imginfo.Extension;
                    img.Resize(600,360);
                    img.Save("~/Uploads/Hizmet/"+logoname);

                    hizmet.ResimUrl = "/Uploads/Hizmet/"+logoname;
                }
                db.Hizmet.Add(hizmet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hizmet);
        }
        public ActionResult Edit(int? id)
        {
            if (id==null)
            {
                ViewBag.Alert = "Bulunamadı";
            }
            var hizmet=db.Hizmet.Find(id);
            if (hizmet == null)
            {
                return HttpNotFound();
            }
            return View(hizmet);
        }
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int? id, Hizmet hizmet,HttpPostedFileBase ResimUrl) 
        {
            if (ModelState.IsValid)
            {
                var h=db.Hizmet.Where(x=>x.HizmetId==id).SingleOrDefault();
                if (ResimUrl != null)
                {
                    if (System.IO.File.Exists(Server.MapPath(h.ResimUrl)))
                    {
                        System.IO.File.Delete(Server.MapPath(h.ResimUrl));
                    }
                    WebImage img = new WebImage(ResimUrl.InputStream);
                    FileInfo imginfo = new FileInfo(ResimUrl.FileName);

                    string hizmetName = ResimUrl.FileName + imginfo.Extension;
                    img.Resize(500, 500);
                    img.Save("~/Uploads/Hizmet/"+ hizmetName);
                    h.ResimUrl = "/Uploads/Hizmet/"+ hizmetName;
                }
                h.Baslik = hizmet.Baslik;
                h.Aciklama=hizmet.Aciklama;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(); 
        }
        public ActionResult Delete(int id)
        {
            var h = db.Hizmet.Find(id);
            if (h==null)
            {
                return HttpNotFound();
            }
            db.Hizmet.Remove(h);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}