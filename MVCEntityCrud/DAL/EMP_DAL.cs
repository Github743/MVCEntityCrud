﻿using MVCCrud.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MVCEntityCrud.DAL
{
    public class EMP_DAL
    {
        public IEnumerable<Employee> List()
        {
            using (var context = new DbContext())
            {
                var employees = context.Employees.ToList();
                return employees;
            }
        }

        public bool Delete(int id)
        {
            using (var context = new DbContext())
            {
                var employee = context.Employees.FirstOrDefault(x => x.EMP_ID == id);
                if (employee != null)
                {
                    context.Employees.Remove(employee);
                    context.SaveChanges();
                    return true;
                }
                return false;
            }
        }

        public Employee GetEmployeeById(int id)
        {
            using (var context = new DbContext())
            {
                return context.Employees.FirstOrDefault(e => e.EMP_ID == id);
            }
        }

        public bool SaveEmployee(Employee employee)
        {
            try
            {
                using (var context = new DbContext())
                {
                    var existingEmployee = context.Employees.FirstOrDefault(e => e.EMP_ID == employee.EMP_ID);
                    if (existingEmployee != null)
                    {
                        existingEmployee.EMP_Name = employee.EMP_Name;
                        existingEmployee.EMP_Salary = employee.EMP_Salary;
                    }
                    else
                    {
                        context.Employees.Add(employee);
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