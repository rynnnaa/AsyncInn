using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsynInnn.Models.Interfaces
{
    public interface IHotelManager 
    {
        //create
        Task CreateHotel(Hotel hotel);

        //read
        Task<Hotel> GetHotel(int? id);
        Task<IEnumerable<Hotel>> GetHotels();

        //update/edit

        Task UpdateHotel(Hotel hotel);


        //delte
        Task DeleteHotel(int id);

        //Check if exists
        bool HotelExists(int id);
    }
}
