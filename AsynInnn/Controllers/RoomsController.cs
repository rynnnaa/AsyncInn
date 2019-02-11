using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AsynInnn.Data;
using AsynInnn.Models;
using AsynInnn.Models.Interfaces;

namespace AsynInnn.Controllers
{
    public class RoomsController : Controller
    {
        /// <summary>
        /// brings in interface
        /// </summary>
        private readonly IRoomManager _context;

        public RoomsController(IRoomManager context)
        {
            _context = context;

        }

        // GET: Rooms
        //public async Task<IActionResult> Index()
        //{
        //    return View(await _context.GetRooms());
        //}
        /// <summary>
        /// Display details for rooms
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Details to view</returns>
        // GET: Rooms/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var room = await _context.GetRoom(id);
            if (room == null)
            {
                return NotFound();
            }

            return View(room);
        }

        /// <summary>
        /// Displays the create view
        /// </summary>
        /// <returns></returns>
        // GET: Rooms/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Rooms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,RoomLayout")] Room room)
        {
            if (ModelState.IsValid)
            {
                await _context.CreateRoom(room);
                return RedirectToAction(nameof(Index));
            }
            return View(room);
        }

        // GET: Rooms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var room = await _context.GetRoom(id);
            if (room == null)
            {
                return NotFound();
            }
            return View(room);
        }

        // POST: Rooms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,RoomLayout")] Room room)
        {
            if (id != room.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _context.UpdateRoom(room);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoomExists(room.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            return View(room);
        }

        /// <summary>
        /// Displays delete view
        /// </summary>
        /// <param name="id"></param>
        /// <returns>delete view</returns>
        // GET: Rooms/Delete/5
        public async Task<IActionResult> Delete(int id)
        {

            var room = await _context.GetRoom(id);
            if (room == null)
            {
                return NotFound();
            }

            return View(room);
        }

        /// <summary>
        /// Deleting one instance
        /// </summary>
        /// <param name="id"></param>
        /// <returns>deletion</returns>
        // POST: Rooms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var room = await _context.GetRoom(id);
            await _context.DeleteRoom(id);
            return RedirectToAction(nameof(Index));
        }
        /// <summary>
        /// Checks to see if room exists
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private bool RoomExists(int id)
        {
            if (_context.GetRoom(id) != null)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Create search bar
        /// </summary>
        /// <param name="searchString"></param>
        /// <returns></returns>
        public async Task<IActionResult> Index(string searchString)
        {
            if (searchString == null)
            {
                return View(await _context.GetRooms());
            }
            var rooms = await _context.GetRooms();

            if (!String.IsNullOrEmpty(searchString))
            {
                rooms = rooms.Where(r => r.Name.ToLower().Contains(searchString.ToLower()));
            }

            return View(rooms);
        }

    }
}
