using System;
using Xunit;
using AsynInnn;
using AsynInnn.Models;
using AsynInnn.Data;
using Microsoft.EntityFrameworkCore;

namespace XUnitTestProject2
{
    public class UnitTest1
    {
        [Fact]
        public void CanGetNameOfHotels()
        {    //instantiates hotel
            Hotel hotel = new Hotel();
            //get name of hotel to Dotnet
            hotel.Name = "DotNet";
            //test that hotel.Name is now Dotnet
            Hotel.Equals("DotNet", hotel.Name);

        }

        [Fact]
        public void CanGetAmenityID()
        {
            Amenities amenities = new Amenities();
            amenities.ID = 1;
            Amenities.Equals(1, amenities.ID);
        }

        [Fact]
        public void CanSetAmenityID()
        {
            Amenities amenities = new Amenities();
            amenities.ID = 2;
            amenities.ID = 1;
            Amenities.Equals(1, amenities.ID);
        }
        [Fact]
        public void CanGetAmenityName()
        {
            Amenities amenities = new Amenities();
            amenities.Name = "Iron";
            Amenities.Equals("Iron", amenities.ID);
        }
        [Fact]
        public void CanSetAmenityName()
        {
            Amenities amenities = new Amenities();
            amenities.Name = "Blow Dryer";
            amenities.Name = "Iron";
            Amenities.Equals("Iron", amenities.ID);
        }
        [Fact]
        public void CanGetHotelID()
        {
            Hotel hotel = new Hotel();
            hotel.ID = 1;
            Hotel.Equals(1, hotel.ID);
        }

        [Fact]
        public void CanSetHotelID()
        {
            Hotel hotel = new Hotel();
            hotel.ID = 2;
            hotel.ID = 1;
            Hotel.Equals(1, hotel.ID);
        }
        [Fact]
        public void CanGetHotelName()
        {
            Hotel hotel = new Hotel();
            hotel.Name = "Hilton";
            Hotel.Equals("Hilton", hotel.Name);
        }
        [Fact]
        public void CanSetHotelName()
        {
            Hotel hotel = new Hotel();
            hotel.Name = "Weston";
            hotel.Name = "Hilton";
            Hotel.Equals("Hilton", hotel.Name);
        }
    }


        //[Fact]
        //public async void CanCreateCourse()
        //{
        //    Microsoft.EntityFrameworkCore.DbContextOptions<AsyncInnDbContext> options = new
        //        DbContextOptionsBuilder<AsyncInnDbContext>().UseInMemoryDatabase
        //        ("CreateHotel").Options;

        //    using (AsyncInnDbContext context = new AsyncInnDbContext
        //        (options))
        //    {
        //        //Arrange
        //        Hotel hotel = new Hotel();
        //        hotel.ID = 1;
        //        hotel.Name = "Dotnet";

        //        //Act
        //        HotelService hotelServices = new HotelService(context);
        //        await hotelServices.CreateHotel(hotel);

        //        var result = context
    }
        }