﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;
using videoStore.DataContext;

namespace videoStore.Migrations
{
    [DbContext(typeof(VideoDBContext))]
    [Migration("20170829145436_VideoInit")]
    partial class VideoInit
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452");

            modelBuilder.Entity("videoStore.Models.CustomerModel", b =>
                {
                    b.Property<int>("CustomerID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CustomerName");

                    b.Property<string>("CustomerPhoneNumber");

                    b.HasKey("CustomerID");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("videoStore.Models.GenreModel", b =>
                {
                    b.Property<int>("GenreID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("GenreName");

                    b.HasKey("GenreID");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("videoStore.Models.MovieModel", b =>
                {
                    b.Property<int>("MovieID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("GenreID");

                    b.Property<string>("MovieDescription");

                    b.Property<string>("MovieName");

                    b.HasKey("MovieID");

                    b.HasIndex("GenreID");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("videoStore.Models.RentalRecordModel", b =>
                {
                    b.Property<int>("RentalID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CustomerID");

                    b.Property<DateTime>("DueDate");

                    b.Property<int>("MovieID");

                    b.Property<DateTime>("RentalDate");

                    b.Property<DateTime>("ReturnDate");

                    b.HasKey("RentalID");

                    b.HasIndex("CustomerID");

                    b.HasIndex("MovieID");

                    b.ToTable("RentalRecords");
                });

            modelBuilder.Entity("videoStore.Models.MovieModel", b =>
                {
                    b.HasOne("videoStore.Models.GenreModel", "GenreModel")
                        .WithMany()
                        .HasForeignKey("GenreID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("videoStore.Models.RentalRecordModel", b =>
                {
                    b.HasOne("videoStore.Models.CustomerModel", "CustomerModel")
                        .WithMany()
                        .HasForeignKey("CustomerID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("videoStore.Models.MovieModel", "MovieModel")
                        .WithMany()
                        .HasForeignKey("MovieID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}