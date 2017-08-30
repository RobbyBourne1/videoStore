using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Index()
        {
            var service = new MovieService(_context); 
            return View(service.GetAllMovies());
        }
        public IActionResult Create()
        {   
            var movieForm = new MovieService(_context);
            return View(movieForm.GetRentalRecord());
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
        public IActionResult Delete()
        {
            return View();
        }
        public IActionResult Edit()
        {
            return View();
        }
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}