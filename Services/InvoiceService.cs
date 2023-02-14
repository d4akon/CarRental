using CarRental.Data;
using CarRental.Models;
using Microsoft.EntityFrameworkCore;

namespace CarRental.Services
{
    public class InvoiceService
    {
        private readonly ApplicationDbContext _context;

        public InvoiceService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Invoice>> GetAllInvoicesAsync()
        {
            return await _context.Invoices.ToListAsync();
        }

        public async Task<Invoice> GetInvoiceByIdAsync(int id)
        {
            return await _context.Invoices.SingleOrDefaultAsync(i => i.Id == id) ?? new Invoice();
        }

        public async Task AddInvoiceAsync(Invoice invoice)
        {
            await _context.Invoices.AddAsync(invoice);
            await _context.SaveChangesAsync();
        }

        public void DeleteInvoice(Invoice invoice)
        {
            _context.Invoices.Remove(invoice);
            _context.SaveChanges();
        }
    }
}
