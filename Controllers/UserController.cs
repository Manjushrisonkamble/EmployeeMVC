using EmployeeMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.AspNetCore.Http;
namespace EmployeeMVC.Controllers

{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Signup()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Signup(User user)
        {


            EmployeeMVCDbContext db = new EmployeeMVCDbContext();


            db.Add(user);

            db.SaveChanges();


            return Redirect("login");

        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();

        }

        [HttpPost]
        public IActionResult Login(User user)
        {
            EmployeeMVCDbContext db = new EmployeeMVCDbContext();


            User usr = db.Users
                .Where(u => u.Email == user.Email)
                   .FirstOrDefault();
            if (usr != null)
            {
                usr.Password.Equals(user.Password);
                HttpContext.Session.SetString("Email", user.Email);
                return RedirectToAction("Employees", "Employee");

            }



            return View();

        }

        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return Redirect("Login");

        }


    }
}
