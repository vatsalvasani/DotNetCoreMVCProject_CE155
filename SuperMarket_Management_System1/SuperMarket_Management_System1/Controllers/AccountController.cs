using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SuperMarket_Management_System1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.Diagnostics;
using SuperMarket_Management_System1.Data;
using SuperMarket_Management_System1.Models;


namespace SuperMarket_Management_System1.Controllers
{
    public class AccountController : Controller
    {
        private readonly SupermarketDbContext _context;

        public AccountController(SupermarketDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Login([Bind("Id,Password")] Admin adm)
        {

            if (adm.Password == "xxxxx" && adm.Id == "zzzzzz")
            {
                    //ModelState.AddModelError("Password", "Invalid login attempt.");
                return View("home");
            }

            else {
                return View("Index");
            }
            //HttpContext.Session.SetString("userId", adm.Id);
       
            //return RedirectToAction("Index", "Home");
        }

        public IActionResult Logout()
        {
            //HttpContext.Session.Clear();
            return View("Index");
        }
    }
}
