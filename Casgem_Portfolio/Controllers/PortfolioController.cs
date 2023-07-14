using Casgem_Portfolio.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Casgem_Portfolio.Controllers
{
    public class PortfolioController : Controller
    {

        CasgemPortfolioEntities db = new CasgemPortfolioEntities();

        // GET: Portfolio
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult PartialHead()
        {
            return PartialView();
        }

        public PartialViewResult PartialNavbar()
        {
            return PartialView();
        }

        public PartialViewResult PartialFeature()
        {
            ViewBag.FeatureTitle = db.TblFeatures.Select(x => x.FeatureTitle).FirstOrDefault();
            ViewBag.FeatureDescription = db.TblFeatures.Select(x => x.FeatureDescription).FirstOrDefault();
            ViewBag.FeatureImageURL = db.TblFeatures.Select(x => x.FeatureImageURL).FirstOrDefault();



            return PartialView();
        }

        public PartialViewResult PartialAbout()
        {
            ViewBag.aboutTitle = db.TblAbouts.Select(x => x.aboutTitle).FirstOrDefault();
            ViewBag.aboutShort = db.TblAbouts.Select(x => x.aboutShort).FirstOrDefault();
            ViewBag.aboutImage = db.TblAbouts.Select(x => x.aboutImage).FirstOrDefault();

            return PartialView();
        }

        public PartialViewResult MyResume()
        {
            var values = db.TblResumes.ToList();
            return PartialView(values);
        }
        public PartialViewResult Service()
        {
            var values = db.TblServices.ToList();

            return PartialView(values);
        }

        public PartialViewResult Statistic()
        {
            ViewBag.TotalService = db.TblServices.Count();
            ViewBag.MessageCount = db.TblMessages.Count();
            ViewBag.TotalThanksMessage = db.TblMessages.Where(x => x.MessageSubmit == "Teşekkür").Count();
            ViewBag.HappyCustomers = "12";
            return PartialView();

           
        }

        public PartialViewResult PartialFooter()
        {
            return PartialView();
        }

        public PartialViewResult PartialReference()
        {
            var values = db.TblReferences.ToList();

            return PartialView(values);
        }
    }
}