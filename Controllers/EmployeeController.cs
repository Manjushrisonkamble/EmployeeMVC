using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeMVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using EmployeeMVC.Filters;

namespace CollageMVC.Controllers
{
    [AuthenticationFilter]
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddEmployee()
        {
            return View();
        }

        
        [HttpPost]
        public IActionResult AddEmployee(Employee employee)
        {


            EmployeeMVCDbContext db = new EmployeeMVCDbContext();

            db.Add(employee);
            db.SaveChanges();

           


            return Redirect("employees");

        }

        [HttpGet]
        public IActionResult UpdateEmployee(int EmpId)
        {

            EmployeeMVCDbContext db = new EmployeeMVCDbContext();
            Employee emp = db.Employees
                    .Where(e => e.Id == EmpId)
                    .FirstOrDefault();





            return View(emp);

        }

        [HttpPost]
        public IActionResult UpdateEmployee(Employee employee)
        {




            EmployeeMVCDbContext db = new EmployeeMVCDbContext();

            Employee emp = db.Employees
                    .Where(e => e.Id == employee.Id)
                    .FirstOrDefault();

            emp.Name = employee.Name;
            emp.Age = employee.Age;
            emp.Department = employee.Department;
            emp.Designation = employee.Designation;
            emp.City = employee.City;
            

            db.Update(emp);

            db.SaveChanges();


            return Redirect("Employees");

        }

        public IActionResult DeleteEmployee(int EmpId)
        {

            EmployeeMVCDbContext db = new EmployeeMVCDbContext();
            Employee stu = db.Employees
                    .Where(e => e.Id == EmpId)
                    .FirstOrDefault();


            db.Employees.Remove(stu);

            db.SaveChanges();


            return Redirect("Employees");

        }

        [HttpGet]
        public IActionResult Employees()
        {
           
            if (HttpContext.Session.Get("Email") != null)
            {
                EmployeeMVCDbContext db = new EmployeeMVCDbContext();

                DbSet<Employee> emps = db.Employees;
                return View(emps.ToList());
            }
            else{

                return RedirectToAction("Login", "User");


            }

        }



    }
}
