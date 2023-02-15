using System;
using CarRental.Data;
using CarRental.Models;
using Microsoft.EntityFrameworkCore;

namespace CarRental.Seed
{
	public class CarRentalSeeder
	{
		private readonly ApplicationDbContext _context;

		public CarRentalSeeder(ApplicationDbContext context)
		{
			_context = context;
		}

		public void Seed()
		{
			if(_context.Database.CanConnect())
			{
                var pendingMigrations = _context.Database.GetPendingMigrations();

                if(pendingMigrations != null && pendingMigrations.Any())
                {
                    _context.Database.Migrate();
                }

                if(!_context.Cars.Any())
                {
                    var cars = GetCars();
                    _context.Cars.AddRange(cars);
                    _context.SaveChanges();
                }

                if (!_context.Locations.Any())
                {
                    var locations = GetLocations();
                    _context.Locations.AddRange(locations);
                    _context.SaveChanges();
                }
            }
		}

		private IEnumerable<Car> GetCars()
		{
			var cars = new List<Car>()
			{
				new Car()
				{
					Brand = "Mazda",
					Model = "B4000",
					Year = 2002,
					DailyRate = 23.5m,
					IsAvailable = true
				},

                new Car()
                {
                    Brand = "BMW",
                    Model = "Z4",
                    Year = 2005,
                    DailyRate = 30.2m,
                    IsAvailable = true
                },

                new Car()
                {
                    Brand = "Porsche",
                    Model = "911",
                    Year = 2006,
                    DailyRate = 56.7m,
                    IsAvailable = true
                },

                new Car()
                {
                    Brand = "Kia",
                    Model = "Rio",
                    Year = 2001,
                    DailyRate = 33.7m,
                    IsAvailable = true
                },

                new Car()
                {
                    Brand = "Mercedes-Benz",
                    Model = " E63 AMG",
                    Year = 2010,
                    DailyRate = 52.4m,
                    IsAvailable = true
                },

                new Car()
                {
                    Brand = "Chevrolet",
                    Model = "Tahoe",
                    Year = 2008,
                    DailyRate = 31.6m,
                    IsAvailable = true
                },

                new Car()
                {
                    Brand = "Audi",
                    Model = "S4",
                    Year = 2008,
                    DailyRate = 36.2m,
                    IsAvailable = true
                },

                new Car()
                {
                    Brand = "Chevrolet",
                    Model = "Suburban 2500",
                    Year = 2012,
                    DailyRate = 32.2m,
                    IsAvailable = true
                },

                new Car()
                {
                    Brand = "Nissan",
                    Model = "Maxima",
                    Year = 2003,
                    DailyRate = 31.3m,
                    IsAvailable = true
                },

                new Car()
                {
                    Brand = "Chevrolet",
                    Model = "Suburban 2500",
                    Year = 2012,
                    DailyRate = 32.2m,
                    IsAvailable = true
                },

                new Car()
                {
                    Brand = "Toyota",
                    Model = "Tundra",
                    Year = 2005,
                    DailyRate = 35.4m,
                    IsAvailable = true
                },

                new Car()
                {
                    Brand = "Nissan",
                    Model = "Armada",
                    Year = 2012,
                    DailyRate = 30.0m,
                    IsAvailable = true
                },

                new Car()
                {
                    Brand = "Acura",
                    Model = "MDX",
                    Year = 2012,
                    DailyRate = 42.1m,
                    IsAvailable = true
                },

                new Car()
                {
                    Brand = "Mitsubishi",
                    Model = "Outlander",
                    Year = 2014,
                    DailyRate = 38.8m,
                    IsAvailable = true
                },

                new Car()
                {
                    Brand = "Volkswagen",
                    Model = "Pointer",
                    Year = 2007,
                    DailyRate = 35.3m,
                    IsAvailable = true
                },

                new Car()
                {
                    Brand = "Audi",
                    Model = "TT",
                    Year = 2014,
                    DailyRate = 45.8m,
                    IsAvailable = true
                },
            };

            return cars;
		}

		private IEnumerable<Location> GetLocations()
		{
            var locations = new List<Location>()
            {
                new Location()
                {
                    Name = "Beverly Hills Public Parking",
                    Address = "345 N Beverly Dr, Beverly Hills, CA 90210, United States",
                    Phone = "310-285-2467",
                    Cars = new List<Car>()
                },

                new Location()
                {
                    Name = "De Lacey Parking Facility",
                    Address = "45 S De Lacey Ave, Pasadena, CA 91105, United States",
                    Phone = "626-356-9725",
                    Cars = new List<Car>()
                },

                new Location()
                {
                    Name = "Balboa Park Parking",
                    Address = "2168 Pan American E Rd, San Diego, CA 92101, United States",
                    Phone = "619-293-3156",
                    Cars = new List<Car>()
                },

                new Location()
                {
                    Name = "American West Parking Services",
                    Address = "840 Sutter St, San Francisco, CA 94109, United States",
                    Phone = "415-596-8743",
                    Cars = new List<Car>()
                },

                new Location()
                {
                    Name = "California Parking",
                    Address = "199 Turk St, San Francisco, CA 94102, United States",
                    Phone = "415-4684-860",
                    Cars = new List<Car>()
                },
            };

            return locations;
		}
	}
}

