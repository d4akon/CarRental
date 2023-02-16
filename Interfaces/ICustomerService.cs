using System;
using CarRental.Models;

namespace CarRental.Interfaces
{
	public interface ICustomerService
	{
        Task<List<Customer>> GetAllCustomersAsync();

        Task<Customer> GetCustomerByIdAsync(int id);

        Task AddCustomerAsync(Customer customer);

        Task DeleteCustomerAsync(Customer customer);

        bool IsCustomerValid(Customer customer);
    }
}

