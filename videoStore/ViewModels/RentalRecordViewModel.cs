using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using videoStore.DataContext;

namespace videoStore.Models
{
    public class RentalRecordViewModel
    {
        public  int MoviesID { get; set; }
        public string MovieName { get; set; }
        public DateTime RentalDate { get; set; } = DateTime.Now;
        public DateTime DueDate { get; set; } = DateTime.Now.AddDays(5);
        public DateTime ReturnDate { get; set; }
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPhoneNumber { get; set; }
        

        public RentalRecordViewModel()
        {
        }

        public RentalRecordViewModel(RentalRecordModel record)
        {
           this.MoviesID = record.MovieID;
           this.MovieName = record.MovieModel.MovieName;
           this.RentalDate = record.RentalDate;
           this.DueDate = record.DueDate;
           this.ReturnDate = record.ReturnDate;
           this.CustomerID = record.CustomerID;
           this.CustomerName = record.CustomerModel.CustomerName;
           this.CustomerPhoneNumber = record.CustomerModel.CustomerPhoneNumber;
        }
    }
}