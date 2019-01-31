using AsynInnn.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsynInnn.Data
{
    public class AsyncInnDbContext : DbContext
    {
        public AsyncInnDbContext(DbContextOptions<AsyncInnDbContext> options) : base(options)
        {
            // no contect needed in this constructor, just needs it available 
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //composite key associations
            modelBuilder.Entity<HotelRoom>().HasKey(ce => new { ce.HotelID, ce.RoomNumber });
            modelBuilder.Entity<RoomAmenities>().HasKey(ce => new { ce.AmenitiesID, ce.RoomID });

            //DATA SEEDING GOES HERE
            modelBuilder.Entity<Hotel>().HasData(

                new Hotel
                {
                    ID = 1,
                    Name = "Async North Seattle",
                    Address = "Seattle, WA",
                    Phone = "(206)123-4567"
                },

                new Hotel
                {
                    ID = 2,
                    Name = "Async South Seattle",
                    Address = "Seattle, WA",
                    Phone = "(206)123-4567"
                },

                new Hotel
                {
                    ID = 3,
                    Name = "Async West Seattle",
                    Address = "Seattle, WA",
                    Phone = "(206)123-4567"
                },

                new Hotel
                {
                    ID = 4,
                    Name = "Async Eastern",
                    Address = "Eastern, WA",
                    Phone = "(206)123-4567"
                },

                new Hotel
                {
                    ID = 5,
                    Name = "Async Western",
                    Address = "Western, WA",
                    Phone = "(206)123-4567"
                }
                );

           
                );
        }
    }

        public DbSet<Amenities> Amenities { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<HotelRoom> HotelRooms { get; set; }
        public DbSet<Room> Room { get; set; }
        public DbSet<RoomAmenities> RoomAmenities { get; set; }
    }
}
