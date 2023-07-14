using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Casgem_Portfolio.Models.Entities;

namespace Casgem_Portfolio.Controllers
{
    public class ServiceController : Controller
    {

        CasgemPortfolioEntities db = new CasgemPortfolioEntities();

        // GET: Service
        public ActionResult Index()
        {
            var values = db.TblServices.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddService()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddService(TblService p)
        {
            db.TblServices.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteService(int id)
        {
            var value = db.TblServices.Find(id);
            db.TblServices.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateService(int id)
        {
            var value = db.TblServices.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateService(TblService p)
        {
            var value = db.TblServices.Find(p.ServiceID); // Find works only for id
            value.ServiceTitle = p.ServiceTitle;
            value.ServiceIcon = p.ServiceIcon;
            value.ServiceNumber = p.ServiceNumber;
            value.ServiceContent = p.ServiceContent;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}