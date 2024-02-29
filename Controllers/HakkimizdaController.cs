using DevExpress.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSiteAdminPanel.Models;

namespace WebSiteAdminPanel.Controllers
{
    public class HakkimizdaController : Controller
    {
        // GET: Hakkimizda
        AdminPanelDatabase db=new AdminPanelDatabase();
        public ActionResult Index()
        {
            ViewBag.Site = db.Site.SingleOrDefault();
            var h = db.Hakkimizda.ToList();
            return View(h);
        }
        public ActionResult Edit(int id) 
        {
            var h=db.Hakkimizda.Where(x=>x.HakkimizdaId==id).FirstOrDefault();
            return View(h);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(int id,Hakkimizda h)
        {
            if (ModelState.IsValid)
            {
                var hakkimizda = db.Hakkimizda.Where(x => x.HakkimizdaId == id).SingleOrDefault();
                hakkimizda.Aciklama = h.Aciklama;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(h);
        }

        WebSiteAdminPanel.Models.AdminPanelDatabase db1 = new WebSiteAdminPanel.Models.AdminPanelDatabase();

        [ValidateInput(false)]
        public ActionResult GridViewPartial()
        {
            var model = db1.Hakkimizda;
            return PartialView("~/Views/Hakkimizda/_GridViewPartial.cshtml", model.ToList());
        }
        
    }
}