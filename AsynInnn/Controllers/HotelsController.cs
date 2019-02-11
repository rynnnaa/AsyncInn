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
    public class HotelsController : Controller
    {
        /// <summary>
        /// brings in interface
        /// </summary>
        private readonly IHotelManager _context;

        public HotelsController(IHotelManager context)
        {
            _context = context;
        }

        //// GET: Hotels
        //public async Task<IActionResult> Index()
        //{
        //    return View(await _context.GetHotels());
        //}

        /// <summary>
        /// Display details for hotels
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Details to view</returns>
        // GET: Hotels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hotel = await _context.GetHotel(id);
            if (hotel == null)
            {
                return NotFound();
            }

            return View(hotel);
        }

        // GET: Hotels/Create
        public IActionResult Create()
        {
            return View();
        }
        /// <summary>
        /// Displays the create view
        /// </summary>
        /// <returns></returns>
        // GET: Amenities/Create
        // POST: Hotels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Address,Phone")] Hotel hotel)
        {
            if (ModelState.IsValid)
            {
                await _context.CreateHotel(hotel);
                return RedirectToAction(nameof(Index));
            }
            return View(hotel);
        }

        // GET: Hotels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hotel = await _context.GetHotel(id);
            if (hotel == null)
            {
                return NotFound();
            }
            return View(hotel);
        }

        // POST: Hotels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Address,Phone")] Hotel hotel)
        {
            if (id != hotel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _context.UpdateHotel(hotel);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HotelExists(hotel.ID))
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
            return View(hotel);
        }


        /// <summary>
        /// Displays delete view
        /// </summary>
        /// <param name="id"></param>
        /// <returns>delete view</returns>
        // GET: Hotels/Delete/5
        public async Task<IActionResult> Delete(int id)
        {

            var hotel = await _context.GetHotel(id);
            if (hotel == null)
            {
                return NotFound();
            }

            return View(hotel);
        }
        /// <summary>
        /// Deleting one instance
        /// </summary>
        /// <param name="id"></param>
        /// <returns>deletion</returns>
        // POST: Hotels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            
            var hotel = await _context.GetHotel(id);
            await _context.DeleteHotel(id);
            return RedirectToAction(nameof(Index));
        }
        /// <summary>
        /// Checks to see if hotel exists
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        private bool HotelExists(int id)
        {
            if (_context.GetHotel(id) != null)
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
                return View(await _context.GetHotels());
            }
            var hotels = await _context.GetHotels();

            if (!String.IsNullOrEmpty(searchString))
            {
                hotels = hotels.Where(h => h.Name.ToLower().Contains(searchString.ToLower()));
            }

            return View(hotels);
        }
    }
}
