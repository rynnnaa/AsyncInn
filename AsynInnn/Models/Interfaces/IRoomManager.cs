using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsynInnn.Models.Interfaces
{
    public interface IRoomManager
    {
        //create
        Task CreateRoom(Room room);

        //read
        Task<Room> GetRoom(int? id);
        Task<IEnumerable<Room>> GetRooms();

        //update/edit

        Task UpdateRoom(Room room);


        //delete
        Task DeleteRoom(int id);

        //Check if exists
        bool RoomExists(int id);
    }
}
