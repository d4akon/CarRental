using CarRental.Data;
using CarRental.Models;
using Microsoft.EntityFrameworkCore;

namespace CarRental.Services
{
    public class ReservationService
    {
        private readonly ApplicationDbContext _context;

        public ReservationService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Reservation>> GetAllReservationsAsync()
        {
            return await _context.Reservations.ToListAsync();
        }

        public async Task<Reservation> GetReservationByIdAsync(int id)
        {
            return await _context.Reservations.SingleOrDefaultAsync(c => c.Id == id) ?? new Reservation();
        }

        public async Task AddReservationAsync(Reservation reservation)
        {
            await _context.Reservations.AddAsync(reservation);
            await _context.SaveChangesAsync();
        }

        public void DeleteReservation(Reservation reservation)
        {
            _context.Reservations.Remove(reservation);
            _context.SaveChanges();
        }
    }
}
