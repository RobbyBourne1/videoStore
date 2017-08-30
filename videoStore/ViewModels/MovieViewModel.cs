using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using videoStore.DataContext;

namespace videoStore.Models
{
    public class MovieViewModel
    {
      public string MovieName { get; set; }
      public string MovieDescription { get; set; } 
      public string GenreName { get; set; } 
      public int MovieID { get; set;}  

      public MovieViewModel()
      {
      }

      public MovieViewModel(MovieModel movie)
      {
          this.MovieName = movie.MovieName;
          this.MovieDescription = movie.MovieDescription;
          this.GenreName = movie.GenreModel?.GenreName;
      }
    }
}