using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using WebSiteAdminPanel.Models;

namespace WebSiteAdminPanel.Controllers
{
    public class AdminController : Controller
    {
        AdminPanelDatabase db=new AdminPanelDatabase();
        public ActionResult Index()
        {
            ViewBag.BlogSayi = db.Blog.Count();
            ViewBag.KategoriSayi = db.Kategori.Count();
            ViewBag.HizmetSayi = db.Hizmet.Count();
            ViewBag.AdminSayi = db.Admin.Count();
            ViewBag.Site = db.Site.SingleOrDefault();
            return View();
        }
        public ActionResult Login()
        {
           
            return View();
        }
        [HttpPost]
        public ActionResult Login(Admin admin) 
        {
            var login = db.Admin.Where(x => x.Mail == admin.Mail).SingleOrDefault();
            if (login.Mail==admin.Mail && login.Sifre==admin.Sifre)
            {
                Session["adminid"] = login.AdminId;
                Session["mail"] = login.Mail;
                return RedirectToAction("Index", "Admin");

            }
            ViewBag.Alert ="Giriş Yapilamadi.!!";
            return View(admin); 
        }
        public ActionResult Logout()
        {
            Session["adminid"] = null;
            Session["mail"] = null;
            Session.Abandon();
            return RedirectToAction("Login","Admin");
        }
        public ActionResult Adminler()
        {
            return View(db.Admin.ToList());
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Admin admin)
        {
            db.Admin.Add(admin);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            var a = db.Admin.Where(x => x.AdminId == id).SingleOrDefault();
            if (a == null)
            {
                return HttpNotFound();
            }  
            return View(a);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(int id, Admin admin)
        {
            if (ModelState.IsValid)
            {
                var a = db.Admin.Where(x => x.AdminId == id).SingleOrDefault();
               
                a.Mail = admin.Mail;
                a.Sifre = admin.Sifre;
                a.Yetki = admin.Yetki;
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(admin);
        }
        public ActionResult Delete(int id)
        {
            var a = db.Admin.Find(id);
            if (a == null)
            {
                return HttpNotFound();
            }
            
            db.Admin.Remove(a);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}