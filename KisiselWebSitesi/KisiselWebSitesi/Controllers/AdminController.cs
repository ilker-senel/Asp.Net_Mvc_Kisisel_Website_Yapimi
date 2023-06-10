using KisiselWebSitesi.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KisiselWebSitesi.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        Context c = new Context();
        [Authorize]
        public ActionResult Index()
        {
            var deger = c.AnaSayfas.ToList();
            return View(deger);
        }
        [Authorize]
        public ActionResult AnaSayfaGetir(int id)
        {
            var deger = c.AnaSayfas.Find(id);
            return View("AnaSayfaGetir", deger);
        }
        [Authorize]
        public ActionResult AnaSayfaGuncelle(AnaSayfa x)
        {
            var ana = c.AnaSayfas.Find(x.Id);
            ana.Isim = x.Isim;
            ana.Unvan = x.Unvan;
            ana.Iletisim = x.Iletisim;
            ana.Profil = x.Profil;
            ana.Aciklama = x.Aciklama;
            c.SaveChanges();
            return RedirectToAction("Index");

        }
        [Authorize]
        public ActionResult IkonListesi()
        {
            var deger = c.Ikonlars.ToList();
            return View(deger);
        }

        [HttpGet]
        [Authorize]
        public ActionResult YeniIkon()
        {
            return View();
        }
        [HttpPost]
        [Authorize]
        public ActionResult YeniIkon(Ikonlar p)
        {
            c.Ikonlars.Add(p);
            c.SaveChanges();
            return RedirectToAction("IkonListesi");
        }

        [Authorize]
        public ActionResult IkonGetir(int id)
        {
            var deger = c.Ikonlars.Find(id);
            return View("IkonGetir", deger);

        }
        [Authorize]
        public ActionResult IkonGuncelle(Ikonlar iko)
        {
            var deger = c.Ikonlars.Find(iko.Id);
            deger.Ikon = iko.Ikon;
            deger.Link = iko.Link;
            c.SaveChanges();
            return RedirectToAction("IkonListesi");
        }
        [Authorize]
        public ActionResult IkonSil(int id)
        {
            var deger = c.Ikonlars.Find(id);
            c.Ikonlars.Remove(deger);
            c.SaveChanges();
            return RedirectToAction("IkonListesi");
        }
    }
}