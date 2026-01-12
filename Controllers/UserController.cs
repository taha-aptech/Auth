using Auth.Data;
using Auth.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Identity;

namespace Auth.Controllers
{
    public class UserController : Controller
    {
        private readonly AppDbContext _context;

        public UserController(AppDbContext context)
        {
            _context = context;
        }

        // Home Page
        //public IActionResult Index()
        //{
        //    return View();
        //}


        public IActionResult Index()
        {
            var user = HttpContext.Session.GetString("user_id");
            if(user != null)
            {
                ViewBag.user_name = HttpContext.Session.GetString("user_name");
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }


        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(Users user)
        {
            // for hashing password
            var hasher = new PasswordHasher<Users>();
            user.password = hasher.HashPassword(user, user.password);

            _context.tbl_users.Add(user);
            _context.SaveChanges();
            return RedirectToAction("Login");
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string log_email, string log_password)
        {
            var row = _context.tbl_users.FirstOrDefault(u => u.email == log_email);

            //if(row != null && row.password == log_password)
            //{
            //    HttpContext.Session.SetString("user_session", row.id.ToString());
            //    return RedirectToAction("Index");
            //}

            if (row != null)
            {
                var hasher = new PasswordHasher<Users>();
                var result = hasher.VerifyHashedPassword(row, row.password, log_password);

                if (result == PasswordVerificationResult.Success)
                {
                    HttpContext.Session.SetString("user_id", row.id.ToString());
                    HttpContext.Session.SetString("user_name", row.name);
                    return RedirectToAction("Index");
                }
            }

            //else part
            ViewBag.error = "Invalid Credentials";
            return View();
        }


        public IActionResult Logout()
        {
            //HttpContext.Session.Clear();
            HttpContext.Session.Remove("user_id");
            return RedirectToAction("Login");
        }

    }

}
