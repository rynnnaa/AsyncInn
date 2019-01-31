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

            modelBuilder.Entity<Room>().HasData(
                new Room
                {
                    ID = 1,
                    Name = "Monarcle",
                    RoomLayout =
                },

                new Room
                {
                    ID = 2,
                    Name = "Sheiseido",
                    RoomLayout = 0
                },

                new Room
                {
                    ID = 3,
                    Name = "Beveren",
                    RoomLayout = Layout.OneBedroom
                },

                new Room
                {
                    ID = 4,
                    Name = "Titan",
                    RoomLayout = Layout.TwoBedroom
                },

                new Room
                {
                    ID = 5,
                    Name = "Oculum",
                    RoomLayout = Layout.OneBedroom
                },

                new Room
                {
                    ID = 6,
                    Name = "Vivica",
                    RoomLayout = Layout.OneBedroom
                }
                );

            modelBuilder.Entity<Amenities>().HasData(
                new Amenities
                {
                    ID = 1,
                    Name = "Dishwasher"
                },

                new Amenities
                {
                    ID = 2,
                    Name = "Washer/Dryer"
                },

                new Amenities
                {
                    ID = 3,
                    Name = "Kitchen"
                },

                new Amenities
                {
                    ID = 4,
                    Name = "Deck"
                },

                new Amenities
                {
                    ID = 5,
                    Name = "Pull-Out-Bed"
                }
                );
        }

        public DbSet<Amenities> Amenities { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<HotelRoom> HotelRooms { get; set; }
        public DbSet<Room> Room { get; set; }
        public DbSet<RoomAmenities> RoomAmenities { get; set; }
    }
}