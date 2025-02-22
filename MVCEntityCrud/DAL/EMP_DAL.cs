using MVCCrud.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MVCEntityCrud.DAL
{
    public class EMP_DAL
    {
        public IEnumerable<Employee> List()
        {
            using (var context = new EmployeeDbContext())
            {
                var employees = context.Employee.ToList();
                return employees;
            }
        }

        public bool Delete(int id)
        {
            using (var context = new EmployeeDbContext())
            {
                var employee = context.Employee.FirstOrDefault(x => x.Id == id);
                if (employee != null)
                {
                    context.Employee.Remove(employee);
                    context.SaveChanges();
                    return true;
                }
                return false;
            }
        }

        public Employee GetEmployeeById(int id)
        {
            using (var context = new EmployeeDbContext())
            {
                return context.Employee.FirstOrDefault(e => e.Id == id);
            }
        }

        public bool SaveEmployee(Employee employee)
        {
            try
            {
                using (var context = new EmployeeDbContext())
                {
                    var existingEmployee = context.Employee.FirstOrDefault(e => e.Id == employee.Id);
                    if (existingEmployee != null)
                    {
                        existingEmployee.Name = employee.Name;
                        existingEmployee.Email = employee.Email;
                        existingEmployee.Position = employee.Position;
                        existingEmployee.Salary = employee.Salary;
                    }
                    else
                    {
                        context.Employee.Add(employee);
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