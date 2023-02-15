using CarRental.Data;
using CarRental.Interfaces;
using CarRental.Models;
using Microsoft.EntityFrameworkCore;

namespace CarRental.Services
{
    public class CarService : ICarService
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
            if(car != null)
            {
                await _context.Cars.AddAsync(car);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteCarAsync(Car car)
        {
            var dbCar = await _context.Cars.FindAsync(car.Id);

            if(dbCar != null)
            {
                _context.Cars.Remove(dbCar);
                await _context.SaveChangesAsync();
            }

        }

        public void SetIsAvailable(Car car, bool isAvailable)
        {
            if (!CarExists(car.Id))
                return;

            car.IsAvailable = isAvailable;

            try
            {
                _context.Update(car);
            }
            catch
            {

            }
        }

        private bool CarExists(int id)
        {
            return (_context.Cars?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

