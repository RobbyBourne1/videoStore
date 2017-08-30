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
    public class MovieController : Controller
    {   
        private readonly VideoDBContext _context;

        public MovieController(VideoDBContext context)
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
    }
}