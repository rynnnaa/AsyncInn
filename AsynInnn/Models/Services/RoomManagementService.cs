using AsynInnn.Data;
using AsynInnn.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsynInnn.Models.Services
{
    public class RoomManagementService : IRoomManager
    {
        private AsyncInnDbContext _context { get; }

        public RoomManagementService(AsyncInnDbContext context)
        {
            _context = context;
        }

        //create
        public async Task CreateRoom(Room room)
        {
            _context.Room.Add(room);
            await _context.SaveChangesAsync();
        }

        //read
        public async Task<IEnumerable<Room>> GetRooms()
        {
            return await _context.Room.ToListAsync();
        }

        public async Task<Room> GetRoom(int? id)
        {
            return await _context.Room.FirstOrDefaultAsync(r => r.ID == id);
        }

        //update
        public async Task UpdateRoom(Room room)
        {
            _context.Room.Update(room);
            await _context.SaveChangesAsync();

        }

        //delete
        public async Task DeleteRoom(int id)
        {
            Room room = _context.Room.FirstOrDefault(r => r.ID == id);
            _context.Room.Remove(room);
            await _context.SaveChangesAsync();

        }

        //bool exists

        public bool RoomExists(int id)
        {
            return _context.Room.Any(r => r.ID == id);
        }
    }
}
