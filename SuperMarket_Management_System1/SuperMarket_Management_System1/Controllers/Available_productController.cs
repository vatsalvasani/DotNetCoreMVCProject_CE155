#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SuperMarket_Management_System1.Data;
using SuperMarket_Management_System1.Models;

namespace SuperMarket_Management_System1.Controllers
{
    public class Available_productController : Controller
    {
        private readonly SupermarketDbContext _context;

        public Available_productController(SupermarketDbContext context)
        {
            _context = context;
        }

        // GET: Available Items
        public async Task<IActionResult> Index()
        {
            return View(await _context.Avail_Product.ToListAsync());
        }


        // GET: Available Items/AddOrEdit
        public IActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
                return View(new Avail_Product());
            else
                return View(_context.Avail_Product.Find(id));
        }

        // POST: Available Items/AddOrEdit
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit([Bind("Id,Name,Company_Name,Quantity,Last_Purchase_Date,Price")] Avail_Product available)
        {
            if (ModelState.IsValid)
            {
                if (available.Id == 0)
                {
                    _context.Add(available);
                }
                else
                    _context.Update(available);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(available);
        }


        // POST: Available Items/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var temp = await _context.Avail_Product.FindAsync(id);
            _context.Avail_Product.Remove(temp);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}