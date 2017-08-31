using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using videoStore.DataContext;
using videoStore.Models;

namespace videoStore.Controllers
{
    public class RentalRecordController : Controller
    {
        private readonly VideoDBContext _context;

        public RentalRecordController(VideoDBContext context)
        {
            _context = context;
        }

        // GET: RentalRecord
        public IActionResult Index()
        {
            var service = new MovieService(_context);
            return View(service.GetAllRentalRecords());
        }

        // GET: RentalRecord/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rentalRecordModel = await _context.RentalRecords
                .Include(r => r.CustomerModel)
                .Include(r => r.MovieModel)
                .SingleOrDefaultAsync(m => m.RentalID == id);
            if (rentalRecordModel == null)
            {
                return NotFound();
            }

            return View(rentalRecordModel);
        }

        // GET: RentalRecord/Create
        public IActionResult Create()
        {
            var movieForm = new MovieService(_context);
            return View(movieForm.CreateRentalRecord());
        }

        [HttpPost]
        public IActionResult CreateRecord(int movie, int customer, DateTime rentaldate, DateTime duedate)
        {
            var newRecord = new RentalRecordModel
            {
                MovieID = movie,
                CustomerID = customer,
                RentalDate = rentaldate,
                DueDate = duedate
            };
            _context.RentalRecords.Add(newRecord);
            _context.SaveChanges();
            return Redirect("Index");
        }

        // GET: RentalRecord/Edit/5
        public async Task<IActionResult> Edit(int? id)
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
        public async Task<IActionResult> Edit(int id, [Bind("RentalID,MovieID,CustomerID,RentalDate,DueDate,ReturnDate")] RentalRecordModel rentalRecordModel)
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

        // GET: RentalRecord/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rentalRecordModel = await _context.RentalRecords
                .Include(r => r.CustomerModel)
                .Include(r => r.MovieModel)
                .SingleOrDefaultAsync(m => m.RentalID == id);
            if (rentalRecordModel == null)
            {
                return NotFound();
            }

            return View(rentalRecordModel);
        }

        // POST: RentalRecord/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rentalRecordModel = await _context.RentalRecords.SingleOrDefaultAsync(m => m.RentalID == id);
            _context.RentalRecords.Remove(rentalRecordModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RentalRecordModelExists(int id)
        {
            return _context.RentalRecords.Any(e => e.RentalID == id);
        }
    }
}
