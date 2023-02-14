namespace CarRental.Models
{
    // Invoice model
    public class Invoice
    {
        public int Id { get; set; }
        public int ReservationId { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public bool IsPaid { get; set; }
        public virtual Reservation Reservation { get; set; }
    }
}
