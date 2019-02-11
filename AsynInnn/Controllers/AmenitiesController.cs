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
    public class AmenitiesController : Controller
    {
        /// <summary>
        /// brings in interface
        /// </summary>
        private readonly IAmenityManager _context;

        public AmenitiesController(IAmenityManager context)
        {
            _context = context;
        }

        //// GET: Amenities
        //public async Task<IActionResult> Index()
        //{
        //    return View(await _context.GetAmenities());
        //}


        /// <summary>
        /// Display details for amenity
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Details to view</returns>
        // GET: Amenities/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var amenities = await _context.GetAmenity(id);
            if (amenities == null)
            {
                return NotFound();
            }

            return View(amenities);
        }

        /// <summary>
        /// Displays the create view
        /// </summary>
        /// <returns></returns>
        // GET: Amenities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Amenities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name")] Amenities amenities)
        {
            if (ModelState.IsValid)
            {

                await _context.CreateAmenity(amenities);
                return RedirectToAction(nameof(Index));
            }
            return View(amenities);
        }

        // GET: Amenities/Edit/5
        public async Task<IActionResult> Edit(int id)
        {

            var amenities = await _context.GetAmenity(id);
            if (amenities == null)
            {
                return NotFound();
            }
            return View(amenities);
        }

        // POST: Amenities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name")] Amenities amenities)
        {
            if (id != amenities.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {

                    await _context.CreateAmenity(amenities);
                }

                catch (DbUpdateConcurrencyException)
                {
                    if (!AmenitiesExists(amenities.ID))
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

            return View(amenities);
        }

        /// <summary>
        /// Displays delete view
        /// </summary>
        /// <param name="id"></param>
        /// <returns>delete view</returns>

        // GET: Amenities/Delete/5
        public async Task<IActionResult> Delete(int id)
        {

            var amenities = await _context.GetAmenity(id);

            if (amenities == null)
            {
                return NotFound();
            }

            return View(amenities);
        }

        /// <summary>
        /// Deleting one instance
        /// </summary>
        /// <param name="id"></param>
        /// <returns>deletion</returns>
        // POST: Amenities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var amenities = await _context.GetAmenity(id);
            await _context.DeleteAmenity(id);
            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// Checks to see if amenity exists
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private bool AmenitiesExists(int id)
        {
            if (_context.GetAmenity(id) != null)
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
                return View(await _context.GetAmenities());
            }
            var amenities = await _context.GetAmenities();

            if (!String.IsNullOrEmpty(searchString))
            {
                amenities = amenities.Where(a => a.Name.ToLower().Contains(searchString.ToLower()));
            }

            return View(amenities);
        }
    }
}
