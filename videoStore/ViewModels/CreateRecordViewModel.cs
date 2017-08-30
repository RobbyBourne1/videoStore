using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using videoStore.DataContext;

namespace videoStore.Models
{
    public class CreateRecordViewModel
    {
        public  List<MovieModel> Movies { get; set; }
        public DateTime RentalDate { get; set; } = DateTime.Now;
        public DateTime DueDate { get; set; } = DateTime.Now.AddDays(5);
        public DateTime ReturnDate { get; set; }
        public List<CustomerModel> Customers { get; set; }
        

        public CreateRecordViewModel()
        {
        }

        public CreateRecordViewModel(RentalRecordModel movieRental)
        {
            this.Customers = new List<CustomerModel>();
            this.Movies = new List<MovieModel>();
        }
    }
}