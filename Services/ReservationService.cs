using System;
using CarRental.Data;
using CarRental.Interfaces;
using CarRental.Models;
using Microsoft.EntityFrameworkCore;

namespace CarRental.Services
{
    public class ReservationService : IReservationService
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
            if(reservation != null)
            {
                await _context.Reservations.AddAsync(reservation);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteReservationAsync(Reservation reservation)
        {
            var dbReservation = await _context.Reservations.FindAsync(reservation.Id);

            if(dbReservation != null)
            {
                _context.Reservations.Remove(reservation);
                _context.SaveChanges();
            }
        }

        public void SetIsPaid(Reservation reservation, bool isPaid)
        {
            if (!ReservaitonExists(reservation.Id))
                return;

            reservation.IsPaid = isPaid;

            try
            {
                _context.Update(reservation);
                _context.SaveChanges();
            }
            catch
            {

            }
        }

        private bool ReservaitonExists(int id)
        {
            return (_context.Reservations?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

