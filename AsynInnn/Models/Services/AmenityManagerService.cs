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


    }
 
}
