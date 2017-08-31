using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using videoStore.DataContext;
using videoStore.Models;

namespace videoStore.Controllers
{
    public class ReturnController : Controller
    {
        private readonly VideoDBContext _context;

        public ReturnController(VideoDBContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var service = new MovieService(_context);
            return View(service.GetAllRentalRecords());
        }

        public async Task<IActionResult> ReturnMovie(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rentalRecordModel = await _context.RentalRecords.SingleOrDefaultAsync(m => m.RentalID == id);
            if (rentalRecordModel == null)
            {
                return NotFound();
            }
            ViewData["CustomerID"] = new SelectList(_context.Customers, "CustomerID", "CustomerID", rentalRecordModel.CustomerID);
            ViewData["MovieID"] = new SelectList(_context.Movies, "MovieID", "MovieID", rentalRecordModel.MovieID);
            return View(rentalRecordModel);
        }

        // POST: RentalRecord/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ReturnMovie(int id, [Bind("RentalID,MovieID,CustomerID,RentalDate,DueDate,ReturnDate")] RentalRecordModel rentalRecordModel)
        {
            if (id != rentalRecordModel.RentalID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rentalRecordModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RentalRecordModelExists(rentalRecordModel.RentalID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerID"] = new SelectList(_context.Customers, "CustomerID", "CustomerID", rentalRecordModel.CustomerID);
            ViewData["MovieID"] = new SelectList(_context.Movies, "MovieID", "MovieID", rentalRecordModel.MovieID);
            return View(rentalRecordModel);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private bool RentalRecordModelExists(int id)
        {
            return _context.RentalRecords.Any(e => e.RentalID == id);
        }
    }
}