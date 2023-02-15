using System;
using CarRental.Models;

namespace CarRental.Interfaces
{
	public interface IInvoiceService
	{
        Task<List<Invoice>> GetAllInvoicesAsync();

        Task<Invoice> GetInvoiceByIdAsync(int id);

        Task AddInvoiceAsync(Invoice invoice);

        Task DeleteInvoiceAsync(Invoice invoice);
    }
}

