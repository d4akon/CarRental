using CarRental.Data;
using CarRental.Models;
using Microsoft.EntityFrameworkCore;

namespace CarRental.Services
{
    public class CarService
    {
        private readonly ApplicationDbContext _context;

        public CarService(ApplicationDbContext context) 
        {
            _context = context;
        }

        public async Task<List<Car>> GetAllCarsAsync()
        {
            return await _context.Cars.ToListAsync();
        }

        public async Task<Car> GetCarByIdAsync(int id)
        {
            return await _context.Cars.SingleOrDefaultAsync(c => c.Id == id) ?? new Car();
        }

        public async Task AddCarAsync(Car car)
        {
            await _context.Cars.AddAsync(car);
            await _context.SaveChangesAsync();
        }

        public void DeleteCar(Car car)
        {
            _context.Cars.Remove(car);
            _context.SaveChanges();
        }
    }
}
