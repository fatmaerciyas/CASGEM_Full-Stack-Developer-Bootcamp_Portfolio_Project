using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Casgem_Portfolio.Models.Entities;

namespace Casgem_Portfolio.Controllers
{
    public class ProjectController : Controller
    {
        CasgemPortfolioEntities db = new CasgemPortfolioEntities();

        public ActionResult Index()
        {
            var values = db.TblProjects.ToList();

            return View(values);
        }

        [HttpGet]
        public ActionResult AddProject()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddProject(TblProject tblProject)
        {
            db.TblProjects.Add(tblProject);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult DeleteProject(int id)
        {
            var value = db.TblProjects.Find(id);
            db.TblProjects.Remove(value);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateProject(int id)
        {
            var value = db.TblProjects.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateProject(TblProject tblProject)
        {
            var value = db.TblProjects.Find(tblProject.ProjectID);
            value.ProjectTitle = tblProject.ProjectTitle;
            value.ProjectDescription = tblProject.ProjectDescription;
            value.ProjectImageUrl = tblProject.ProjectImageUrl;
            value.ProjectLink = tblProject.ProjectLink;
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}