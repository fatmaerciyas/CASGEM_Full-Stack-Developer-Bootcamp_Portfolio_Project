using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Casgem_Portfolio.Models.Entities;

namespace Casgem_Portfolio.Controllers
{
    public class ContactController : Controller
    {
        CasgemPortfolioEntities db = new CasgemPortfolioEntities();
        // GET: Contact
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Index(TblMessage p)
        {
            db.TblMessages.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index", "Portfolio");
        }
    }
}