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
    public class HomeController : Controller
    {
        private readonly VideoDBContext _context;

        public HomeController(VideoDBContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Return()
        {
            return View();
        }
        public IActionResult Overdue()
        {
            return View();
        }

        // public IActionResult Seed()
        // {
        //     var seedGenre = new List<GenreModel>()
        // {
        //     new GenreModel
        //     {
        //         GenreName = "Horror"
        //     },
        //      new GenreModel
        //     {
        //         GenreName = "Comedy"
        //     },
        //      new GenreModel
        //     {
        //         GenreName = "Action"
        //     }
        // };

        //     seedGenre.ForEach(genre => _context.Genres.Add(genre));

        //     var seedMovies = new List<MovieModel>()
        //     {
        //         new MovieModel
        //         {
        //         MovieName = "John Wick",
        //         MovieDescription = "Shootem Bang Bang",
        //         GenreID = 3
        //         },
        //         new MovieModel
        //         {
        //         MovieName = "SuperBad",
        //         MovieDescription = "Laugh Haha",
        //         GenreID = 2
        //         },
        //         new MovieModel
        //         {
        //         MovieName = "Evil Dead",
        //         MovieDescription = "Scary Run scared",
        //         GenreID = 1
        //         }
        //     };
        //     seedMovies.ForEach(vid => _context.Movies.Add(vid));
            
        //     var seedCustomers = new List<CustomerModel>()
        //     {
        //         new CustomerModel
        //         {
        //             CustomerName = "Robby",
        //             CustomerPhoneNumber = "8675309"
        //         },
        //         new CustomerModel
        //         {
        //             CustomerName = "Yana",
        //             CustomerPhoneNumber = "1234567"
        //         },
        //         new CustomerModel
        //         {
        //             CustomerName = "Jeremiah",
        //             CustomerPhoneNumber = "9876543"
        //         },
        //     };
        //     seedCustomers.ForEach(person => _context.Customers.Add(person));

        //     _context.SaveChanges();

        //     return Ok();
        // }
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
