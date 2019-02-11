using AsynInnn.Models.Interfaces;
using AsynInnn.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsynInnn.Models.Services
{
    public class AmenityManagerService : IAmenityManager
    {
        private AsyncInnDbContext _context { get; }

        public AmenityManagerService(AsyncInnDbContext context)
        {
            _context = context;
        }

        //create
        public async Task CreateAmenity(Amenities amenities)
        {
            _context.Amenities.Add(amenities);
            await _context.SaveChangesAsync();
        }

        //read
        public async Task<IEnumerable<Amenities>> GetAmenities()
        {
            return await _context.Amenities.ToListAsync();
        }

        public async Task<Amenities> GetAmenity(int? id)
        {
            return await _context.Amenities.FirstOrDefaultAsync(a => a.ID == id);
        }

        //update
        public async Task UpdateAmenity(Amenities amenities)
        {
            _context.Amenities.Update(amenities);
            await _context.SaveChangesAsync();

        }

        //delete
        public async Task DeleteAmenity(int id)
        {
            Amenities amenity = _context.Amenities.FirstOrDefault(a => a.ID == id);
            _context.Amenities.Remove(amenity);
            await _context.SaveChangesAsync();

        }

        //bool exists

        public bool AmenityExists(int id)
        {
            return _context.Amenities.Any(a => a.ID == id);
        }

    }
 
}
