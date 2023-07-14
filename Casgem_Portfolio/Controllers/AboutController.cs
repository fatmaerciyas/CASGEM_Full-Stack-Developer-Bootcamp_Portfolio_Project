using System.Linq;
using System.Web.Mvc;
using Casgem_Portfolio.Models.Entities;

namespace Casgem_Portfolio.Controllers
{
    public class AboutController : Controller
    {
        private readonly CasgemPortfolioEntities db = new CasgemPortfolioEntities();
        public ActionResult Index()
        {
            var values = db.TblAbouts.ToList();

            return View(values);
        }

        [HttpGet]
        public ActionResult UpdateAbout(int id)
        {
            var value = db.TblAbouts.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateAbout(TblAbout tblAbout)
        {
            var value = db.TblAbouts.Find(tblAbout.ID);
            value.aboutTitle = tblAbout.aboutTitle;
            value.aboutShort = tblAbout.aboutShort;
            value.aboutImage = tblAbout.aboutImage;
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}