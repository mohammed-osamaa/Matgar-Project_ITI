using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ProjectITI.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace ProjectITI.Controllers
{
    public class UserController : Controller
    {
        Context _context = new Context();
        public IActionResult Index()
        {
            var _users = _context.Users;
            return View(_users);
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(User user)
        {
            ModelState.Remove("User");
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "All Fields Required");
                return View();
            }
            _context.Users.Add(user);
            _context.SaveChanges();
            return RedirectToAction("Login");
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(User user)
        {
            var CheckedUser = _context.Users.FirstOrDefault(u => u.Email == user.Email && u.Password == user.Password);
            if (CheckedUser == null)
            {
                ModelState.AddModelError("", "The Email Or Password is Invalid.");
                return View();
            }
            return RedirectToAction("Index", "Product");
        }
    }
}
