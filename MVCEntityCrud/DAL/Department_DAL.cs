using MVCCrud.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCEntityCrud.DAL
{
	public class Department_DAL
	{
        public IEnumerable<Department> List()
        {
            using (var context = new DbContext())
            {
                var Department = context.Departments.ToList();
                return Department;
            }
        }
        public bool Delete(int id)
        {
            using (var context = new DbContext())
            {
                var department = context.Departments.FirstOrDefault(x => x.Department_ID == id);
                if (department != null)
                {
                    context.Departments.Remove(department);
                    context.SaveChanges();
                    return true;
                }
                return false;
            }
        }

        public Department GetDepartmentById(int id)
        {
            using (var context = new DbContext())
            {
                return context.Departments.FirstOrDefault(e => e.Department_ID == id);
            }
        }

        public bool SaveDepartment(Department department)
        {
            try
            {
                using (var context = new DbContext())
                {
                    var existingEmployee = context.Departments.FirstOrDefault(e => e.Department_ID == department.Department_ID);
                    if (existingEmployee != null)
                    {
                        existingEmployee.Department_Name = department.Department_Name;
                    }
                    else
                    {
                        context.Departments.Add(department);
                    }
                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

    }

}