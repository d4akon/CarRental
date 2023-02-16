using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CarRental.Data;
using CarRental.Models;
using CarRental.Services;

namespace CarRental.Controllers
{
    public class ReservationsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly CarService _carService;

        public ReservationsController(ApplicationDbContext context, CarService carService)
        {
            _context = context;
            _carService = carService;
        }

        // GET: Reservations
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Reservations.Include(r => r.Car).Include(r => r.Customer).Include(r => r.PickupLocation).Include(r => r.ReturnLocation);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Reservations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Reservations == null)
            {
                return NotFound();
            }

            var reservation = await _context.Reservations
                .Include(r => r.Car)
                .Include(r => r.Customer)
                .Include(r => r.PickupLocation)
                .Include(r => r.ReturnLocation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reservation == null)
            {
                return NotFound();
            }

            return View(reservation);
        }

        // GET: Reservations/Create
        public IActionResult Create()
        {
            ViewData["CarId"] = new SelectList(_context.Cars, "Id", "Brand");
            ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "FirstName");
            ViewData["PickupLocationId"] = new SelectList(_context.Locations, "Id", "Id");
            ViewData["ReturnLocationId"] = new SelectList(_context.Locations, "Id", "Id");
            return View();
        }

        // POST: Reservations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CarId,CustomerId,PickupLocationId,ReturnLocationId,PickupDate,ReturnDate,TotalCost,IsPaid")] Reservation reservation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reservation);
                await _context.SaveChangesAsync();
                //todo uncomment when ready
                //_carService.SetIsAvailable(reservation.Car, false);
                return RedirectToAction(nameof(Index));
            }
            ViewData["CarId"] = new SelectList(_context.Cars, "Id", "Brand", reservation.CarId);
            ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "FirstName", reservation.CustomerId);
            ViewData["PickupLocationId"] = new SelectList(_context.Locations, "Id", "Id", reservation.PickupLocationId);
            ViewData["ReturnLocationId"] = new SelectList(_context.Locations, "Id", "Id", reservation.ReturnLocationId);
            return View(reservation);
        }

        // GET: Reservations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Reservations == null)
            {
                return NotFound();
            }

            var reservation = await _context.Reservations.FindAsync(id);
            if (reservation == null)
            {
                return NotFound();
            }
            ViewData["CarId"] = new SelectList(_context.Cars, "Id", "Brand", reservation.CarId);
            ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "FirstName", reservation.CustomerId);
            ViewData["PickupLocationId"] = new SelectList(_context.Locations, "Id", "Id", reservation.PickupLocationId);
            ViewData["ReturnLocationId"] = new SelectList(_context.Locations, "Id", "Id", reservation.ReturnLocationId);
            return View(reservation);
        }

        // POST: Reservations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CarId,CustomerId,PickupLocationId,ReturnLocationId,PickupDate,ReturnDate,TotalCost,IsPaid")] Reservation reservation)
        {
            if (id != reservation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reservation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReservationExists(reservation.Id))
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
            ViewData["CarId"] = new SelectList(_context.Cars, "Id", "Brand", reservation.CarId);
            ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "FirstName", reservation.CustomerId);
            ViewData["PickupLocationId"] = new SelectList(_context.Locations, "Id", "Id", reservation.PickupLocationId);
            ViewData["ReturnLocationId"] = new SelectList(_context.Locations, "Id", "Id", reservation.ReturnLocationId);
            return View(reservation);
        }

        // GET: Reservations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Reservations == null)
            {
                return NotFound();
            }

            var reservation = await _context.Reservations
                .Include(r => r.Car)
                .Include(r => r.Customer)
                .Include(r => r.PickupLocation)
                .Include(r => r.ReturnLocation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reservation == null)
            {
                return NotFound();
            }

            return View(reservation);
        }

        // POST: Reservations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Reservations == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Reservations'  is null.");
            }
            var reservation = await _context.Reservations.FindAsync(id);
            if (reservation != null)
            {
                _context.Reservations.Remove(reservation);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReservationExists(int id)
        {
          return (_context.Reservations?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
