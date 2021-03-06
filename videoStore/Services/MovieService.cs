using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using videoStore.DataContext;
using videoStore.Models;

namespace videoStore
{
    class MovieService
    {
        private readonly VideoDBContext _context;

        public MovieService(VideoDBContext context)
        {
            _context = context;
        }

        public IEnumerable<MovieViewModel> GetAllMovies()
        {
            var CurrentMovies = _context.Movies;
            return CurrentMovies.Include(i => i.GenreModel).Select(s => new MovieViewModel(s));
        }

        public CreateRecordViewModel CreateRentalRecord()
        {
            var customerInfo = _context.Customers;
            var movieInfo = _context.Movies;
            var newRecord = new CreateRecordViewModel
            {
                Customers = customerInfo.ToList(),
                Movies = movieInfo.ToList(),
            };

            return newRecord;
        }

        public IEnumerable<RentalRecordViewModel> GetAllRentalRecords()
        {
            var RentalRecord = _context.RentalRecords;
            return RentalRecord.Include(i => i.MovieModel)
            .Include(i => i.CustomerModel)
            .Select(s => new RentalRecordViewModel(s));
        }

        private static Func<RentalRecordModel, bool> hasDefaultDate => w => w.ReturnDate == default(DateTime);

        public IEnumerable<RentalRecordViewModel> GetOverdueRecords()
        {
            var customerInfo = _context.Customers;
            var movieInfo = _context.Movies;
            var allRecords = _context.RentalRecords;
            var today = DateTime.Today;

            return allRecords
                .Include(m => m.MovieModel)
                .Include(c => c.CustomerModel)
                .Where(hasDefaultDate)
                .Where(t => t.DueDate.CompareTo(today) < 0)
                .Select(s => new RentalRecordViewModel(s));
        }

        public IEnumerable<RentalRecordViewModel> GetCheckedOutRecords()
        {
            var RentalRecord = _context.RentalRecords;
            return RentalRecord
                .Include(i => i.MovieModel)
                .Include(i => i.CustomerModel).Where(hasDefaultDate)
                .Select(s => new RentalRecordViewModel(s));
        }
    }
}