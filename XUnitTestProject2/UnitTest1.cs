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