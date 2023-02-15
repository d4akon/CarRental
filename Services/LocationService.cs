using System;
using CarRental.Data;
using CarRental.Interfaces;
using CarRental.Models;
using Microsoft.EntityFrameworkCore;

namespace CarRental.Services
{
    public class LocationService : ILocationService
    {
        private readonly ApplicationDbContext _context;

        public LocationService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Location>> GetAllLocationsAsync()
        {
            return await _context.Locations.ToListAsync();
        }

        public async Task<Location> GetLocationByIdAsync(int id)
        {
            return await _context.Locations.SingleOrDefaultAsync(c => c.Id == id) ?? new Location();
        }

        public async Task AddLocationAsync(Location location)
        {
            if(location != null)
            {
                await _context.Locations.AddAsync(location);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteLocationAsync(Location location)
        {
            var dbLocation = await _context.Locations.FindAsync(location.Id);

            if(dbLocation != null)
            {
                _context.Locations.Remove(dbLocation);
                await _context.SaveChangesAsync();
            }
        }
    }
}

