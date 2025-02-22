using MVCCrud.Model;
using MVCEntityCrud.DAL;
using System;
using System.Web.Mvc;

namespace MVCEntityCrud.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EMP_DAL emp_DAL = new EMP_DAL();
        // GET: Employee
        public ActionResult Index()
        {
            var employees = emp_DAL.List();
            return View(employees);

        }

        public ActionResult Create()
        {
            return PartialView("_EditEmployee", new Employee());
        }
        [HttpPost]
        public JsonResult Save(Employee employee)
        {
            try
            {
                return Json(new { success = emp_DAL.SaveEmployee(employee) });
            }
            catch
            {
                return Json(new { success = false });
            }
        }


        [HttpPost]
        public JsonResult Delete(int id)
        {
            try
            {
                return Json(new { success = emp_DAL.Delete(id) });
            }
            catch
            {
                return Json(new { success = false });
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var employee = emp_DAL.GetEmployeeById(id);
            return PartialView("_EditEmployee", employee);
        }
    }
}