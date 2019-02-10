using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsynInnn.Models.Interfaces
{
    public interface IAmenityManager
    {
        //create
        Task CreateAmenity(Amenities amenities);

        //read
        Task<Amenities> GetAmenity(int? id);
        Task<IEnumerable<Amenities>> GetAmenities();

        //update/edit

        Task UpdateAmenity(Amenities amenites);


        //delte
        Task DeleteAmenity(int id);

        //Check if exists
        bool AmenityExists(int id);
    }
}
