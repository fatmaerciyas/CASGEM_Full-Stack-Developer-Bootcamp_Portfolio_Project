using Casgem_Portfolio.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Casgem_Portfolio.Controllers
{
    public class MessageController : Controller
    {
        CasgemPortfolioEntities db = new CasgemPortfolioEntities();

        // GET: Service
        public ActionResult Index()
        {
            var values = db.TblMessages.ToList();
            return View(values);
        }

        public ActionResult DeleteMessage(int id)
        {
            var value = db.TblMessages.Find(id);
            db.TblMessages.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult MessageDetails(int id)
        {
            var value = db.TblMessages.Find(id);
            return View(value);
        }
    }
}

//mesaj detay kısmı düzelt
//referanslar admin
//admin kısmı tamamlanacak

//yarın features admin, istatistik yapacağız