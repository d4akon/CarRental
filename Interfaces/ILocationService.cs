using System;
using CarRental.Models;

namespace CarRental.Interfaces
{
	public interface ILocationService
	{
        Task<List<Location>> GetAllLocationsAsync();

        Task<Location> GetLocationByIdAsync(int id);

        Task AddLocationAsync(Location location);

        Task DeleteLocationAsync(Location location);
    }
}

