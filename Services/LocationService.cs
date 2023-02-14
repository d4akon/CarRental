using CarRental.Models;
using CarRental.Data;
using Microsoft.EntityFrameworkCore;

namespace LocationRental.Services
{
    public class LocationService
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
            await _context.Locations.AddAsync(location);
            await _context.SaveChangesAsync();
        }

        public void DeleteLocation(Location location)
        {
            _context.Locations.Remove(location);
            _context.SaveChanges();
        }
    }
}
