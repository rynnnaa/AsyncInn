using System;
using Xunit;
using AsynInnn;
using AsynInnn.Models;
using AsynInnn.Models.Services;
using AsynInnn.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;

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

        [Fact]
        public void CanGetHotelAddress()
        {
            Hotel hotel = new Hotel();
            hotel.Address = "West";
            Hotel.Equals("West", hotel.Address);
        }

        [Fact]
        public void CanSetHotelAddress()
        {
            Hotel hotel = new Hotel();
            hotel.Address = "South";
            hotel.Address = "West";
            Hotel.Equals("West", hotel.Address);
        }
        [Fact]
        public void CanGetHotelPhone()
        {
            Hotel hotel = new Hotel();
            hotel.Phone = "Number";
            Hotel.Equals("Number", hotel.Phone);
        }

        [Fact]
        public void CanSetHotelPhone()
        {
            Hotel hotel = new Hotel();
            hotel.Phone = "Number2";
            hotel.Phone = "Number";
            Hotel.Equals("Number", hotel.Phone);
        }

        [Fact]
        public void CanGetHotelRoomID()
        {
            HotelRoom hotelRoom = new HotelRoom();
            hotelRoom.HotelID = 2;
            HotelRoom.Equals(2, hotelRoom.HotelID);
        }

        [Fact]
        public void CanSetHotelRoomID()
        {
            HotelRoom hotelRoom = new HotelRoom();
            hotelRoom.HotelID = 3;
            hotelRoom.HotelID = 2;
            HotelRoom.Equals(2, hotelRoom.HotelID);
        }

        [Fact]
        public void CanGetHotelRoomNumber()
        {
            HotelRoom hotelRoom = new HotelRoom();
            hotelRoom.RoomNumber = 2;
            HotelRoom.Equals(2, hotelRoom.RoomNumber);
        }

        [Fact]
        public void CanSetHotelRoomNumber()
        {
            HotelRoom hotelRoom = new HotelRoom();
            hotelRoom.RoomNumber = 3;
            hotelRoom.RoomNumber = 2;
            HotelRoom.Equals(2, hotelRoom.RoomNumber);
        }

        [Fact]
        public void CanGetRoomID()
        {
            HotelRoom hotelRoom = new HotelRoom();
            hotelRoom.RoomID = 3;
            HotelRoom.Equals(2, hotelRoom.RoomID);
        }

        [Fact]
        public void CanSetRoomID()
        {
            HotelRoom hotelRoom = new HotelRoom();
            hotelRoom.RoomID = 3;
            hotelRoom.RoomID = 2;
            HotelRoom.Equals(2, hotelRoom.RoomID);
        }

        [Fact]
        public void CanGetRoomRate()
        {
            HotelRoom hotelRoom = new HotelRoom();
            hotelRoom.Rate = 2;
            HotelRoom.Equals(2, hotelRoom.Rate);
        }


        [Fact]
        public void CanSetRoomRate()
        {
            HotelRoom hotelRoom = new HotelRoom();
            hotelRoom.Rate = 3;
            hotelRoom.Rate = 2;
            HotelRoom.Equals(2, hotelRoom.Rate);
        }

        [Fact]
        public void CanGetPetFriendly()
        {
            HotelRoom hotelRoom = new HotelRoom();
            hotelRoom.PetFriendly = true;
            HotelRoom.Equals(true, hotelRoom.PetFriendly);
        }

        [Fact]
        public void CanSetPetFriendly()
        {
            HotelRoom hotelRoom = new HotelRoom();
            hotelRoom.PetFriendly = true;
            hotelRoom.PetFriendly = false;
            HotelRoom.Equals(false, hotelRoom.PetFriendly);
        }

        [Fact]
        public void CanGetRoomIDNumber()
        {
            Room room = new Room();
            room.ID = 1;
            Room.Equals(1, room.ID);

        }

        [Fact]
        public void CanSetRoomIDNumber()
        {
            Room room = new Room();
            room.ID = 2;
            room.ID = 1;
            Room.Equals(1, room.ID);

        }
        [Fact]
        public void CanGetRoomName()
        {
            Room room = new Room();
            room.Name = "YourRoom";
            Room.Equals("YourRoom", room.Name);
        }

        [Fact]
        public void CanSetRoomName()
        {
            Room room = new Room();
            room.Name = "MyRoom";
            room.Name = "YourRoom";
            Room.Equals("YourRoom", room.Name);

        }
        [Fact]
        public void CanSetRoomLayout()
        {
            Room room = new Room();
            room.RoomLayout = Layout.OneBedroom;
            room.RoomLayout = Layout.TwoBedroom;
            Assert.Equal(Layout.TwoBedroom, room.RoomLayout);

        }

        [Fact]
        public void CanGetRoomLayout()
        {
            Room room = new Room();
            room.RoomLayout = Layout.TwoBedroom;
            Assert.Equal(Layout.TwoBedroom, room.RoomLayout);
        }

        [Fact]
        public void CanGetRoomAmenitiesID()
        {
            RoomAmenities roomAmenities = new RoomAmenities();
            roomAmenities.AmenitiesID = 1;
            Assert.Equal(1, roomAmenities.AmenitiesID);
        }


        [Fact]
        public void CanSetRoomAmenitiesID()
        {
            RoomAmenities roomAmenities = new RoomAmenities();
            roomAmenities.AmenitiesID = 1;
            roomAmenities.AmenitiesID = 2;
            Assert.Equal(2, roomAmenities.AmenitiesID);
        }

        [Fact]
        public void CanGetRoomAmenitiesRoomID()
        {
            RoomAmenities roomAmenities = new RoomAmenities();
            roomAmenities.RoomID = 2;
            Assert.Equal(2, roomAmenities.RoomID);
        }

        [Fact]
        public void CanSetRoomAmenitiesRoomID()
        {
            RoomAmenities roomAmenities = new RoomAmenities();
            roomAmenities.RoomID = 1;
            roomAmenities.RoomID = 2;
            Assert.Equal(2, roomAmenities.RoomID);
        }


        [Fact]
        public async void CanCreateHotel()
        {
            Microsoft.EntityFrameworkCore.DbContextOptions<AsyncInnDbContext> options = new
                DbContextOptionsBuilder<AsyncInnDbContext>().UseInMemoryDatabase
                ("CreateHotel").Options;

            using (AsyncInnDbContext context = new AsyncInnDbContext
                (options))
            {
                //Arrange
                Hotel hotel = new Hotel();
                hotel.ID = 1;
                hotel.Name = "Dotnet";

                //Act
                HotelManagementService hotelServices = new HotelManagementService(context);
                await hotelServices.CreateHotel(hotel);

                var result = context.Hotels.FirstOrDefault(h => h.HotelRoom == h.HotelRoom);

                Assert.Equal(hotel, result);
            }
        }

        [Fact]
        public async void CanReadHotel()
        {
            Microsoft.EntityFrameworkCore.DbContextOptions<AsyncInnDbContext> options = new
                DbContextOptionsBuilder<AsyncInnDbContext>().UseInMemoryDatabase
                ("CreateHotel").Options;

            using (AsyncInnDbContext context = new AsyncInnDbContext
                (options))
            {
                //Arrange
                Hotel hotel = new Hotel();
                hotel.ID = 1;
                hotel.Name = "Dotnet";

                //Act
                HotelManagementService hotelServices = new HotelManagementService(context);
                await hotelServices.CreateHotel(hotel);
                await hotelServices.GetHotel(1);

                var result = context.Hotels.FirstOrDefault(h => h.HotelRoom == h.HotelRoom);

                Assert.Equal(hotel, result);
            }
        }
        [Fact]
        public async void CanUpdateHotel()
        {
            Microsoft.EntityFrameworkCore.DbContextOptions<AsyncInnDbContext> options = new
                DbContextOptionsBuilder<AsyncInnDbContext>().UseInMemoryDatabase
                ("CreateHotel").Options;

            using (AsyncInnDbContext context = new AsyncInnDbContext
                (options))
            {
                //Arrange
                Hotel hotel = new Hotel();
                hotel.ID = 1;
                hotel.Name = "Dotnet";

                //Act
                HotelManagementService hotelServices = new HotelManagementService(context);
                await hotelServices.CreateHotel(hotel);
                await hotelServices.UpdateHotel(hotel);

                var result = context.Hotels.FirstOrDefault(h => h.HotelRoom == h.HotelRoom);

                Assert.Equal(hotel, result);
            }
        }

        public async void CanDeleteHotel()
        {
            Microsoft.EntityFrameworkCore.DbContextOptions<AsyncInnDbContext> options = new
                DbContextOptionsBuilder<AsyncInnDbContext>().UseInMemoryDatabase
                ("CreateHotel").Options;

            using (AsyncInnDbContext context = new AsyncInnDbContext
                (options))
            {
                //Arrange
                Hotel hotel = new Hotel();
                hotel.ID = 1;
                hotel.Name = "Dotnet";

                //Act
                HotelManagementService hotelServices = new HotelManagementService(context);
                await hotelServices.CreateHotel(hotel);
                await hotelServices.DeleteHotel(1);

                var result = context.Hotels.FirstOrDefault(h => h.HotelRoom == h.HotelRoom);

                Assert.Null(result);
            }


        }
    }
}