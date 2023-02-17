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
					DailyRate = 23,
					IsAvailable = true,
                    ImageUrl = "https://cdn.jdpower.com/ChromeImageGallery/Expanded/Transparent/640/2008MAZ001a_640/2008MAZ001a_640_01.png"
                },

                new Car()
                {
                    Brand = "BMW",
                    Model = "Z4",
                    Year = 2005,
                    DailyRate = 30,
                    IsAvailable = true,
                    ImageUrl = "https://cdn.jdpower.com/ChromeImageGallery/Expanded/Transparent/640/2008BMW010b_640/2008BMW010b_640_01.png"
                },

                new Car()
                {
                    Brand = "Porsche",
                    Model = "911",
                    Year = 2006,
                    DailyRate = 56,
                    IsAvailable = true,
                    ImageUrl = "https://cdn.jdpower.com/ChromeImageGallery/Expanded/Transparent/640/2015POR001c_640/2015POR001c_640_01.png"
                },

                new Car()
                {
                    Brand = "Kia",
                    Model = "Rio",
                    Year = 2001,
                    DailyRate = 33,
                    IsAvailable = true,
                    ImageUrl = "https://platform.cstatic-images.com/xlarge/in/v2/stock_photos/0f44ed25-68a1-4073-8b27-ea77bf2d5603/dff65fdf-b4e2-4b92-9a5d-161960d582d0.png"

                },

                new Car()
                {
                    Brand = "Mercedes-Benz",
                    Model = " E63 AMG",
                    Year = 2010,
                    DailyRate = 52,
                    IsAvailable = true,
                    ImageUrl = "https://cdn.jdpower.com/ChromeImageGallery/Expanded/Transparent/640/2010MEB005a_640/2010MEB005a_640_01.png"

                },

                new Car()
                {
                    Brand = "Chevrolet",
                    Model = "Tahoe",
                    Year = 2008,
                    DailyRate = 31,
                    IsAvailable = true,
                    ImageUrl = "https://cdn.jdpower.com/ChromeImageGallery/Expanded/Transparent/640/2008CHE018a_640/2008CHE018a_640_01.png"
                },

                new Car()
                {
                    Brand = "Audi",
                    Model = "S4",
                    Year = 2008,
                    DailyRate = 36,
                    IsAvailable = true,
                    ImageUrl = "https://cdn.jdpower.com/ChromeImageGallery/Expanded/Transparent/640/2008AUD009a_640/2008AUD009a_640_01.png"
                },

                new Car()
                {
                    Brand = "Chevrolet",
                    Model = "Suburban 2500",
                    Year = 2021,
                    DailyRate = 32,
                    IsAvailable = true,
                    ImageUrl = "https://s3.us-east-2.amazonaws.com/dealer-inspire-vps-vehicle-images/stock-images/chrome/96f302f03f100dbdf37598e1e69ee4d5.png"
                },

                new Car()
                {
                    Brand = "Nissan",
                    Model = "Maxima",
                    Year = 2003,
                    DailyRate = 31,
                    IsAvailable = true,
                    ImageUrl = "https://cdn.jdpower.com/ChromeImageGallery/Expanded/Transparent/640/2008NIS007a_640/2008NIS007a_640_01.png"
                },

                new Car()
                {
                    Brand = "Toyota",
                    Model = "Tundra",
                    Year = 2005,
                    DailyRate = 35,
                    IsAvailable = true,
                    ImageUrl = "https://images.iconfigurators.app/images/vehicles/reference/Toyota-Tundra-SR5-TRD-Crew-Max-Short-Bed-2003_2006.png"
                },

                new Car()
                {
                    Brand = "Nissan",
                    Model = "Armada",
                    Year = 2012,
                    DailyRate = 23,
                    IsAvailable = true,
                    ImageUrl = "https://www.cars.com/i/large/in/v2/stock_photos/132b8433-c329-44b4-8516-6687a820147b/7450a15f-a181-474f-bd45-138f65c7a146.png"
                },

                new Car()
                {
                    Brand = "Acura",
                    Model = "MDX",
                    Year = 2012,
                    DailyRate = 42,
                    IsAvailable = true,
                    ImageUrl = "https://cdn.jdpower.com/ChromeImageGallery/Expanded/Transparent/640/2012ACU001a_640/2012ACU001a_640_01.png"
                },

                new Car()
                {
                    Brand = "Mitsubishi",
                    Model = "Outlander",
                    Year = 2014,
                    DailyRate = 38,
                    IsAvailable = true,
                    ImageUrl = "https://cdn.jdpower.com/ChromeImageGallery/Expanded/Transparent/640/2014MIT005a_640/2014MIT005a_640_01.png"
                },

                new Car()
                {
                    Brand = "Volkswagen",
                    Model = "Tiguan",
                    Year = 2021,
                    DailyRate = 41,
                    IsAvailable = true,
                    ImageUrl = "https://65e81151f52e248c552b-fe74cd567ea2f1228f846834bd67571e.ssl.cf1.rackcdn.com/ldm-images/2021-Volkswagen-Tiguan-hero.png"
                },

                new Car()
                {
                    Brand = "Audi",
                    Model = "TT",
                    Year = 2014,
                    DailyRate = 45,
                    IsAvailable = true,
                    ImageUrl = "https://cdn.jdpower.com/ChromeImageGallery/Expanded/Transparent/640/2014AUD013a_640/2014AUD013a_640_01.png"
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
                },

                new Location()
                {
                    Name = "De Lacey Parking Facility",
                    Address = "45 S De Lacey Ave, Pasadena, CA 91105, United States",
                    Phone = "626-356-9725",
                },

                new Location()
                {
                    Name = "Balboa Park Parking",
                    Address = "2168 Pan American E Rd, San Diego, CA 92101, United States",
                    Phone = "619-293-3156",
                },

                new Location()
                {
                    Name = "American West Parking Services",
                    Address = "840 Sutter St, San Francisco, CA 94109, United States",
                    Phone = "415-596-8743",
                },

                new Location()
                {
                    Name = "California Parking",
                    Address = "199 Turk St, San Francisco, CA 94102, United States",
                    Phone = "415-4684-860",
                },
            };

            return locations;
		}
	}
}

