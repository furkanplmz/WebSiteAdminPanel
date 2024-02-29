using DevExpress.Web.Mvc;
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
    public class SiteController : Controller
    {
        AdminPanelDatabase db=new AdminPanelDatabase();
        public ActionResult Index()
        {
            ViewBag.Site = db.Site.SingleOrDefault();
            return View(db.Site.ToList());
        }

        // GET: Site/Edit/5
        public ActionResult Edit(int id)
        {
            var site = db.Site.Where(x => x.SiteId == id).SingleOrDefault();
            return View(site);
        }

        // POST: Site/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(int id, Site site, HttpPostedFileBase LogoUrl)
        {
            if (ModelState.IsValid)
            {
                var s = db.Site.Where(x => x.SiteId == id).SingleOrDefault();

                if (LogoUrl !=null)
                {
                    if (System.IO.File.Exists(Server.MapPath(s.LogoUrl)))
                    {
                        System.IO.File.Delete(Server.MapPath(s.LogoUrl));
                    }

                    WebImage img = new WebImage(LogoUrl.InputStream);
                    FileInfo imginfo= new FileInfo(LogoUrl.FileName);

                    string logoname=LogoUrl.FileName+imginfo.Extension;
                    img.Resize(200, 200);
                    img.Save("~/Uploads/Site/" + logoname);
                    s.LogoUrl = "/Uploads/Site/"+logoname ;
                }
                s.Baslik=site.Baslik;
                s.Tanim=site.Tanim;
                s.AnahtarKelimeler = site.AnahtarKelimeler;
                s.Unvan=site.Unvan;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(site);
        }

        WebSiteAdminPanel.Models.AdminPanelDatabase db1 = new WebSiteAdminPanel.Models.AdminPanelDatabase();

        [ValidateInput(false)]
        public ActionResult GridViewPartial()
        {
            var model = db1.Site;
            return PartialView("~/Views/Site/_GridViewPartial.cshtml", model.ToList());
        }
   
    }
}
