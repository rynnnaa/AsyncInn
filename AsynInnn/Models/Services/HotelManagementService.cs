using AsynInnn.Data;
using AsynInnn.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsynInnn.Models.Services
{
    public class HotelManagementService : IHotelManager
    {
        private AsyncInnDbContext _context { get; }

        public HotelManagementService(AsyncInnDbContext context)
        {
            _context = context;
        }

        //create
        public async Task CreateHotel(Hotel hotel)
        { 
            _context.Hotels.Add(hotel);
            await _context.SaveChangesAsync();
        }

        //read
        public async Task<IEnumerable<Hotel>> GetHotels()
        {
            return await _context.Hotels.ToListAsync();
        }

        public async Task<Hotel> GetHotel(int? id)
        {
            return await _context.Hotels.FirstOrDefaultAsync(htl => htl.ID == id);
        }

        //update
        public async Task UpdateHotel(Hotel hotel)
        {
            _context.Hotels.Update(hotel);
            await _context.SaveChangesAsync();

        }

        //delete
        public async Task DeleteHotel(int id)
        {
            Hotel hotel = _context.Hotels.FirstOrDefault(h => h.ID == id);
            _context.Hotels.Remove(hotel);
            await _context.SaveChangesAsync();

        }

        //bool exists

        public bool HotelExists(int id)
        {
            return _context.Hotels.Any(h => h.ID == id);
        }

    }
}
