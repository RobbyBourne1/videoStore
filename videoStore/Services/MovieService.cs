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
    {   private readonly VideoDBContext _context;

        public MovieService(VideoDBContext context)
        {
            _context = context;
        }

        public IEnumerable<MovieViewModel> GetAllMovies()
        {
            var CurrentMovies = _context.Movies;
            return CurrentMovies.Include(i => i.GenreModel).Select(s => new MovieViewModel(s));
        }
    }
}