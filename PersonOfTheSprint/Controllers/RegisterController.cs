using System.Linq;
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

        [HttpPost]
        public JsonResult CheckEmailAvailability(string email)
        {
            var currentEmailAddresses = _context.Users.FirstOrDefault(x => x.Email == email);
            return Json(currentEmailAddresses == null);
        }
    }
}