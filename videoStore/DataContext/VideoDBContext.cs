using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using videoStore.Models;

namespace videoStore.DataContext
{
    public partial class VideoDBContext : DbContext
    {
         public DbSet<GenreModel> Genres {get;set;}
         public DbSet<MovieModel> Movies {get;set;}
         public DbSet<RentalRecordModel> RentalRecords {get;set;}
         public DbSet<CustomerModel> Customers {get;set;}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseNpgsql(@"Host=localhost;Database=VideoDB;Username=dev;Password=dev");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {}
    }
}
