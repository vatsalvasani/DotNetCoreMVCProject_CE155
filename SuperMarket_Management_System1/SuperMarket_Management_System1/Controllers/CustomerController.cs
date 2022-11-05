#nullable disable
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MimeKit;
using SuperMarket_Management_System1.Data;
using SuperMarket_Management_System1.Models;

namespace SuperMarket_Management_System1.Controllers
{
    public class CustomerController : Controller
    {
        private readonly SupermarketDbContext _context;

        public CustomerController(SupermarketDbContext context)
        {
            _context = context;
        }

        // GET: Customer
        public async Task<IActionResult> Index()
        {
            return View(await _context.Customer.ToListAsync());
        }

        public IActionResult Particular(int id = 0)
        {
            if (id == 0)
                return View(new Customer());
            else
                return View(_context.Customer.Find(id));
        }
        public async Task<IActionResult> Particular1(String type)
        {
            return View(await _context.Customer.Where(x => x.Type == type).ToListAsync());
        }


        // GET: Customer/AddOrEdit
        public IActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
                return View(new Customer());
            else
                return View(_context.Customer.Find(id));
        }

        // POST: Customer/AddOrEdit
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit([Bind("CustomerId,Customer_Name,Company_Name,Type,Last_Purchase,Total_Purchase,Mobile,Email")] Customer cust)
        {
            if (ModelState.IsValid)
            {
                if (cust.CustomerId == 0)
                {
                    _context.Add(cust);
                }
                else
                    _context.Update(cust);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cust);
        }


        // POST: Customer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var temp = await _context.Customer.FindAsync(id);
            _context.Customer.Remove(temp);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Mail() {
            string tex = Request.Form["mailtext"].ToString();
            string sub = Request.Form["subject"].ToString();

            var s = _context.Customer.ToList();
            //samir56@ethereal.email
            
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("SuperMarket", "vatsalvasani22882@gmail.com"));

            foreach (var m in s)
            {
                message.To.Add(new MailboxAddress(m.Customer_Name, m.Email));
            }
            message.Subject = sub;
            message.Body = new TextPart("Plain")
            {
                Text = tex
            //"SuperMarket greeting You On The Auspicious Ocassion Of Diwali....Wishing You And Your Family A Very Happy Diwali."
            };
            using (var Client = new SmtpClient())
            {
                Client.Connect("smtp.gmail.com", 587, false);
                Client.Authenticate("vatsalvasani22882@gmail.com", "ipauqztiqejugsku");
                Client.Send(message);
                Client.Disconnect(true);
            
            }
            return View();

        }

        [HttpPost]
        public IActionResult Mail_1()
        {
            string tex = Request.Form["mailtext"].ToString();
            string sub = Request.Form["subject"].ToString();

            var s = _context.Customer.Where(x => x.Type == "Silver").ToList();
            //samir56@ethereal.email

            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("SuperMarket", "vatsalvasani22882@gmail.com"));

            foreach (var m in s)
            {
                message.To.Add(new MailboxAddress(m.Customer_Name, m.Email));
            }
            message.Subject = sub;
            message.Body = new TextPart("Plain")
            {
                Text = tex
                //"SuperMarket greeting You On The Auspicious Ocassion Of Diwali....Wishing You And Your Family A Very Happy Diwali."
            };
            using (var Client = new SmtpClient())
            {
                Client.Connect("smtp.gmail.com", 587, false);
                Client.Authenticate("vatsalvasani22882@gmail.com", "ipauqztiqejugsku");
                Client.Send(message);
                Client.Disconnect(true);

            }
            return View();

        }
        [HttpPost]
        public IActionResult Mail_2()
        {
            string tex = Request.Form["mailtext"].ToString();
            string sub = Request.Form["subject"].ToString();

            var s = _context.Customer.Where(x => x.Type == "Golden").ToList();
            //samir56@ethereal.email

            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("SuperMarket", "vatsalvasani22882@gmail.com"));

            foreach (var m in s)
            {
                message.To.Add(new MailboxAddress(m.Customer_Name, m.Email));
            }
            message.Subject = sub;
            message.Body = new TextPart("Plain")
            {
                Text = tex
                //"SuperMarket greeting You On The Auspicious Ocassion Of Diwali....Wishing You And Your Family A Very Happy Diwali."
            };
            using (var Client = new SmtpClient())
            {
                Client.Connect("smtp.gmail.com", 587, false);
                Client.Authenticate("vatsalvasani22882@gmail.com", "ipauqztiqejugsku");
                Client.Send(message);
                Client.Disconnect(true);

            }
            return View();

        }
        [HttpPost]
        public IActionResult Mail_3()
        {
            string tex = Request.Form["mailtext"].ToString();
            string sub = Request.Form["subject"].ToString();
            var s = _context.Customer.Where(x => x.Type == "Platinium").ToList();
            //samir56@ethereal.email

            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("SuperMarket", "vatsalvasani22882@gmail.com"));

            foreach (var m in s)
            {
                message.To.Add(new MailboxAddress(m.Customer_Name, m.Email));
            }
            message.Subject = sub;
            message.Body = new TextPart("Plain")
            {
                Text = tex
                //"SuperMarket greeting You On The Auspicious Ocassion Of Diwali....Wishing You And Your Family A Very Happy Diwali."
            };
            using (var Client = new SmtpClient())
            {
                Client.Connect("smtp.gmail.com", 587, false);
                Client.Authenticate("vatsalvasani22882@gmail.com", "ipauqztiqejugsku");
                Client.Send(message);
                Client.Disconnect(true);

            }
            return View();

        }
        public IActionResult Mail1()
        {
            return View();
        }
        
        public IActionResult Mail2()
        {
            return View();
        }
        
        public IActionResult Mail3()
        {
            return View();
        }
        public IActionResult Mail4()
        {
            return View();
        }

    }
}