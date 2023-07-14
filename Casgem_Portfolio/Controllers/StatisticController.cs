using System.Linq;
using System.Web.Mvc;
using Casgem_Portfolio.Models.Entities;

namespace Casgem_Portfolio.Controllers
{
    public class StatisticController : Controller
    {
        private readonly CasgemPortfolioEntities db = new CasgemPortfolioEntities();
        public ActionResult Index()
        {
            ViewBag.employeeCount = db.TblEmployees.Count();

            var salary = db.TblEmployees.Max(x => x.EmployeeSalary);
            ViewBag.maxSalaryEmployee = db.TblEmployees.Where(x => x.EmployeeSalary == salary)
                .Select(y => y.EmployeeName + " " + y.EmployeeSurname).FirstOrDefault();

            ViewBag.totalCityCount = db.TblEmployees.Select(x => x.EmployeeCity).Distinct().Count();

            ViewBag.avgEmployeeSalary = db.TblEmployees.Average(x => x.EmployeeSalary);


            ViewBag.countSoftwareDepartment = db.TblEmployees.
                Count(x => x.EmployeeDepartment == db.TblDepartments.
                    Where(z => z.DepartmentName == "Yazılım").
                Select(y => y.ID).FirstOrDefault());

            ViewBag.cityAnkaraOrAdanaSumSalary = db.TblEmployees
                .Where(x => x.EmployeeCity == "Ankara" || x.EmployeeCity == "Adana")
                .Sum(y => y.EmployeeSalary);

            ViewBag.sumSalaryFromSoftwareDepartment = db.TblEmployees.Where(x =>
                    x.EmployeeCity == "Ankara" && x.EmployeeDepartment == db.TblDepartments
                        .Where(z => z.DepartmentName == "Yazılım").Select(y => y.ID).FirstOrDefault())
                .Sum(w => w.EmployeeSalary);

            return View();
        }
    }
}