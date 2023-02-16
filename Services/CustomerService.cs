using CarRental.Data;
using CarRental.Interfaces;
using CarRental.Models;
using Microsoft.EntityFrameworkCore;

namespace CarRental.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ApplicationDbContext _context;

        public CustomerService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Customer>> GetAllCustomersAsync()
        {
            return await _context.Customers.ToListAsync();
        }

        public async Task<Customer> GetCustomerByIdAsync(int id)
        {
            return await _context.Customers.SingleOrDefaultAsync(c => c.Id == id) ?? new Customer();
        }

        public async Task<Customer> GetCustomerByUserGuidAsync(string guid)
        {
            return await _context.Customers.SingleOrDefaultAsync(c => c.UserId == guid) ?? new Customer();
        }

        public async Task AddCustomerAsync(Customer customer)
        {
            if(IsCustomerValid(customer))
            {
                await _context.Customers.AddAsync(customer);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteCustomerAsync(Customer customer)
        {
            var dbCustomer = await _context.Customers.FindAsync(customer.Id);

            if(dbCustomer != null)
            {
                _context.Customers.Remove(dbCustomer);
                await _context.SaveChangesAsync();
            }
        }

        public bool IsCustomerValid(Customer customer)
        {
            return customer.FirstName != null &&
                customer.LastName != null &&
                customer.LicenseNumber != null &&
                customer.Phone != null;

        }

    }
}

