using System;
using CarRental.Models;

namespace CarRental.Interfaces
{
	public interface IReservationService
	{
        Task<List<Reservation>> GetAllReservationsAsync();

        Task<Reservation> GetReservationByIdAsync(int id);

        Task AddReservationAsync(Reservation reservation);

        Task DeleteReservationAsync(Reservation reservation);
    }
}

