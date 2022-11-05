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

namespace Supermarket_Management_System.Controllers
{
    public class transaction1Controller : Controller
    {
        private readonly SupermarketDbContext _context;

        public transaction1Controller(SupermarketDbContext context)
        {
            _context = context;
        }

        // GET: Transaction
        public async Task<IActionResult> Index()
        {
            return View(await _context.transaction1.ToListAsync());
        }


        // GET: Transaction/AddOrEdit
        public IActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
                return View(new transaction1());
            else
                return View(_context.transaction1.Find(id));
        }
        public IActionResult Particular(int id = 0)
        {
            if (id == 0)
                return View(new transaction1());
            else
                return View(_context.transaction1.Find(id));
        }
        public async Task<IActionResult> Particular1(DateTime date)
        {
            return View(await _context.transaction1.Where(x => x.Date == date).ToListAsync());
        }

        // POST: Transaction/AddOrEdit
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit([Bind("transaction1Id,Customer_Name,Total_Amount,Date")] transaction1 tra)
        {
            if (ModelState.IsValid)
            {
                if (tra.transaction1Id == 0)
                {
                    _context.Add(tra);
                }
                else
                    _context.Update(tra);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tra);
        }


        // POST: Transaction/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var temp = await _context.transaction1.FindAsync(id);
            _context.transaction1.Remove(temp);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}