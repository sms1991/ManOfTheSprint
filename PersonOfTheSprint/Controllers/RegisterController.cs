using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PersonOfTheSprint.Models;
using PersonOfTheSprint.ViewModels;

namespace PersonOfTheSprint.Controllers
{
    public class RegisterController : Controller
    {
        private readonly PersonOfTheSprintDbContext _context = new PersonOfTheSprintDbContext();
        // GET: Register
        public ActionResult Index()
        {
            var user = new RegisterViewModel();
            return View(user);
        }

        [HttpPost]
        public ActionResult RegisterUser(RegisterViewModel user)
        {
            if (!ModelState.IsValid) return View("Index");

           //var c =  CheckEmailAvailability(user.Email);

            //if (CheckEmailAvailability(user.Email))
            //{
            //    //ModelState.AddModelError("", "This email address has already been taken.");
            //   // return View("Index", user);
            //}

            user.Password = HashThePassword(user.Password);

            var newUser = new User
            {
                Email = user.Email,
                Password = user.Password
            };

            _context.Users.Add(newUser);
            _context.SaveChanges();

            return View("Index");
        }

        private string HashThePassword(string password)
        {
           return  BCrypt.Net.BCrypt.HashPassword(password, 4);
        }

        //[HttpPost]
        //public bool CheckEmailAvailability(string email)
        //{
        //    var currentEmailAddresses = _context.Users.FirstOrDefault(x => x.Email == email);

        //    if (currentEmailAddresses != null)
        //    {
        //        return String.Equals(email, currentEmailAddresses.Email, StringComparison.OrdinalIgnoreCase);
        //    }

        //    return false;
        //}

        [HttpPost]
        public JsonResult CheckEmailAvailability(string email)
        {
            var currentEmailAddresses = _context.Users.FirstOrDefault(x => x.Email == email);
            return Json(currentEmailAddresses == null);
        }
    }
}