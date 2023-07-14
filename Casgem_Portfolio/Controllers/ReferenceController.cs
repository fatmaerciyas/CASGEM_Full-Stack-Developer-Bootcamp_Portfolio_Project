using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Casgem_Portfolio.Models.Entities;

namespace Casgem_Portfolio.Controllers
{
    public class ReferenceController : Controller
    {
        CasgemPortfolioEntities db = new CasgemPortfolioEntities();

        public ActionResult Index()
        {
            var value = db.TblReferences.ToList();

            return View(value);
        }

        [HttpGet]
        public ActionResult AddReference()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddReference(TblReference tblReference)
        {
            db.TblReferences.Add(tblReference);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult DeleteReference(int id)
        {
            var value = db.TblReferences.Find(id);
            db.TblReferences.Remove(value);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateReference(int id)
        {
            var value = db.TblReferences.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateReference(TblReference tblReference)
        {
            var value = db.TblReferences.Find(tblReference.ReferenceID);
            value.NameSurname = tblReference.NameSurname;
            value.HomeTown = tblReference.HomeTown;
            value.Thoughts = tblReference.Thoughts;
            value.ImageLink = tblReference.ImageLink;
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}