using System;
using CarRental.Models;

namespace CarRental.Interfaces
{
	public interface ICarService
	{
		Task<List<Car>> GetAllCarsAsync();

		Task<Car> GetCarByIdAsync(int id);

		Task AddCarAsync(Car car);

		Task DeleteCarAsync(Car car);

		void SetIsAvailable(Car car, bool isAvailable);
    }
}

