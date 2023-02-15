using System;
using CarRental.Data;
using CarRental.Interfaces;
using CarRental.Models;
using Microsoft.EntityFrameworkCore;

namespace CarRental.Services
{
    public class InvoiceService : IInvoiceService
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
            if (invoice != null)
            {
                await _context.Invoices.AddAsync(invoice);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteInvoiceAsync(Invoice invoice)
        {
            var dbInvoice = await _context.Invoices.FindAsync(invoice.Id);

            if(dbInvoice != null)
            {
                _context.Invoices.Remove(dbInvoice);
                await _context.SaveChangesAsync();
            }
        }

        public async Task GenerateInvoiceAsync(Reservation reservation)
        {
            var invoice = new Invoice()
            {
                ReservationId = reservation.Id,
                Date = DateTime.Now,
                Amount = reservation.TotalCost,
                IsPaid = true
            };

            await AddInvoiceAsync(invoice);

            //_reservationService.SetIsPaid(reservation, true);
        }
    }
}

