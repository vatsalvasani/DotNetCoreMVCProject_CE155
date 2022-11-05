using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuperMarket_Management_System1.Data;
using SuperMarket_Management_System1.Models;
using System.Diagnostics;

namespace SuperMarket_Management_System1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SupermarketDbContext _context;
        //public HomeController(ILogger<HomeController> logger)
        //{
         //   _logger = logger;
       // }
        public HomeController(SupermarketDbContext context)
        {
            _context = context;
        }

        // GET: Available Items
        public async Task<IActionResult> Index()
        {
            return View(await _context.Avail_Product.ToListAsync());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}