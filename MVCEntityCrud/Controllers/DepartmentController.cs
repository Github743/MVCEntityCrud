using MVCCrud.Model;
using MVCEntityCrud.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCEntityCrud.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly Department_DAL Department_DAL = new Department_DAL();
        // GET: Department
        public ActionResult Index()
        {
            var Department = Department_DAL.List();
            return View(Department);
        }

        public ActionResult Create()
        {
            return PartialView("_EditDepartment", new Department());
        }
        [HttpPost]
        public JsonResult Save(Department department)
        {
            try
            {
                return Json(new { success = Department_DAL.SaveDepartment(department) });
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
                return Json(new { success = Department_DAL.Delete(id) });
            }
            catch
            {
                return Json(new { success = false });
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var department = Department_DAL.GetDepartmentById(id);
            return PartialView("_EditDepartment", department);
        }
    }
}