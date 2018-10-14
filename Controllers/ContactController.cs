using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contact10.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Contact10.Controllers
{
    public class ContactController : Controller
    {
        //private UserManager<IdentityUser> userManager;
        //private SignInManager<IdentityUser> signInManager;


        private readonly ContactDBContext _context;
        public ContactController(/*UserManager<IdentityUser> um, SignInManager<IdentityUser> sm,*/ ContactDBContext context)
        {
            //userManager = um;
            //signInManager = sm;
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Get()
        {
            return Json(_context.Contact.ToList());
        }

        public IActionResult GetById(int id)
        {
            return Json(_context.Contact.Find(id));
        }

        [HttpPost]
        public IActionResult Create([FromBody] Contact cvm)
        {
            Contact con = new Contact();
           
            con.email = cvm.email;
            _context.Contact.Add(con);
            _context.SaveChanges();
            return Json(true);
        }

        public IActionResult Delete(int id)
        {
            _context.Contact.Remove(_context.Contact.Find(id));
            _context.SaveChanges();
            return Json(true);

        }

        [HttpPost]
        public IActionResult Edit(int id, [FromBody] CVM con)
        {
            var co = (from c in _context.Contact where id == c.id select c).First();
            co.email = con.email;
            _context.SaveChanges();
            return Json(true);
        }
        //[HttpGet]
        //public IActionResult Login() => View();

        //public IActionResult Login(string email, string pass, string returnUrl = null)
        //{
        //    IdentityUser user = userManager.FindByEmailAsync(email).Result;

        //    var signin = signInManager.PasswordSignInAsync(user, pass, false, false).Result;
        //    if (signin.Succeeded)
        //    {
        //        return RedirectToAction("Index");
        //    }
        //    return View();
        //}

        //public IActionResult Logout(string ReturnUrl = null)
        //{
        //    signInManager.SignOutAsync();
        //    if (ReturnUrl != null)
        //    {
        //        return LocalRedirect(ReturnUrl);
        //    }
        //    return RedirectToAction("Login");
        //}

    }
}