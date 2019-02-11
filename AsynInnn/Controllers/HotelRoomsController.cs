using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AsynInnn.Data;
using AsynInnn.Models;

namespace AsynInnn.Controllers 
{
    public class HotelRoomsController : Controller
    {
        private readonly AsyncInnDbContext _context;

        public HotelRoomsController(AsyncInnDbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Gets the list of all hotel rooms =
        /// </summary>
        /// <returns>view</returns>
        // GET: HotelRooms
        public async Task<IActionResult> Index()
        {
            var asyncInnDbContext = _context.HotelRooms.Include(h => h.Hotel).Include(h => h.Room);
            return View(await asyncInnDbContext.ToListAsync());
        }

        /// <summary>
        /// Gives details of one hotel room
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: HotelRooms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hotelRoom = await _context.HotelRooms
                .Include(h => h.Hotel)
                .Include(h => h.Room)
                .FirstOrDefaultAsync(m => m.HotelID == id);
            if (hotelRoom == null)
            {
                return NotFound();
            }

            return View(hotelRoom);
        }

        /// <summary>
        /// Creates an instance of hotel room
        /// </summary>
        /// <returns></returns>
        // GET: HotelRooms/Create
        public IActionResult Create()
        {
            ViewData["HotelID"] = new SelectList(_context.Hotels, "ID", "ID");
            ViewData["RoomID"] = new SelectList(_context.Room, "ID", "ID");
            return View();
        }

        // POST: HotelRooms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HotelID,RoomNumber,RoomID,Rate,PetFriendly")] HotelRoom hotelRoom)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hotelRoom);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["HotelID"] = new SelectList(_context.Hotels, "ID", "Name", hotelRoom.HotelID);
            ViewData["RoomID"] = new SelectList(_context.Room, "ID", "Name", hotelRoom.RoomID);
            return View(hotelRoom);
        }

        /// <summary>
        /// Edit details of hotel room
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: HotelRooms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hotelRoom = await _context.HotelRooms.FindAsync(id);
            if (hotelRoom == null)
            {
                return NotFound();
            }
            ViewData["HotelID"] = new SelectList(_context.Hotels, "ID", "ID", hotelRoom.HotelID);
            ViewData["RoomID"] = new SelectList(_context.Room, "ID", "ID", hotelRoom.RoomID);
            return View(hotelRoom);
        }

        // POST: HotelRooms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HotelID,RoomNumber,RoomID,Rate,PetFriendly")] HotelRoom hotelRoom)
        {
            if (id != hotelRoom.HotelID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hotelRoom);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HotelRoomExists(hotelRoom.HotelID))
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
            ViewData["HotelID"] = new SelectList(_context.Hotels, "ID", "ID", hotelRoom.HotelID);
            ViewData["RoomID"] = new SelectList(_context.Room, "ID", "ID", hotelRoom.RoomID);
            return View(hotelRoom);
        }

        /// <summary>
        /// shows delete page
        /// </summary>
        /// <param name="roomID"></param>
        /// <param name="hotelID"></param>
        /// <returns></returns>
        // GET: HotelRooms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hotelRoom = await _context.HotelRooms
                .Include(h => h.Hotel)
                .Include(h => h.Room)
                .FirstOrDefaultAsync(m => m.HotelID == id);
            if (hotelRoom == null)
            {
                return NotFound();
            }

            return View(hotelRoom);
        }


        /// <summary>
        /// Deletes a selected hotel room
        /// </summary>
        /// <param name="roomID"></param>
        /// <param name="hotelID"></param>
        /// <returns></returns>
        // POST: HotelRooms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hotelRoom = await _context.HotelRooms.FindAsync(id);
            _context.HotelRooms.Remove(hotelRoom);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// Verifies hotel room exitis
        /// </summary>
        /// <param name="id"></param>
        /// <returns>true or false</returns>
        private bool HotelRoomExists(int id)
        {
            return _context.HotelRooms.Any(e => e.HotelID == id);
        }
    }
}
