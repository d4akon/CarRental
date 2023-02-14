using CarRental.Data;
using CarRental.Models;
using Microsoft.EntityFrameworkCore;

namespace CarRental.Services
{
    public class CustomerService
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

        public async Task AddCustomerAsync(Customer customer)
        {
            await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();
        }

        public void DeleteCustomer(Customer customer)
        {
            _context.Customers.Remove(customer);
            _context.SaveChanges();
        }
    }
}
