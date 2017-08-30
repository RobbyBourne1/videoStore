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
            var CurrentMovies = _context.Movies.ToList();
            return View(CurrentMovies);
        }
        public IActionResult Create()
        {
            return View();
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