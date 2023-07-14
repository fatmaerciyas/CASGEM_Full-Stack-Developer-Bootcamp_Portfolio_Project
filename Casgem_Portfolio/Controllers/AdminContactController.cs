using System.Linq;
using System.Web.Mvc;
using Casgem_Portfolio.Models.Entities;

namespace Casgem_Portfolio.Controllers
{
    public class AdminContactController : Controller
    {
        private CasgemPortfolioEntities db = new CasgemPortfolioEntities();
        public ActionResult Index()
        {
            var values = db.TblContacts.ToList();

            return View(values);
        }

        [HttpGet]
        public ActionResult UpdateContact(int id)
        {
            var value = db.TblContacts.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateContact(TblContact tblContact)
        {
            var value = db.TblContacts.Find(tblContact.ContactID);
            value.PhoneNumber = tblContact.PhoneNumber;
            value.Email = tblContact.Email;
            value.Location = tblContact.Location;
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}