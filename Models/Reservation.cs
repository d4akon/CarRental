namespace CarRental.Models
{
    // Reservation model
    public class Reservation
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public int CustomerId { get; set; }
        public int PickupLocationId { get; set; }
        public int ReturnLocationId { get; set; }
        public DateTime PickupDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public decimal TotalCost { get; private set; }
        public bool IsPaid { get; set; }
        public virtual Car? Car { get; set; }
        public virtual Customer? Customer { get; set; }
        public virtual Location? PickupLocation { get; set; }
        public virtual Location? ReturnLocation { get; set; }

        public void SetTotalCost(decimal dailyRate)
        {
            TotalCost = dailyRate * (ReturnDate - PickupDate).Days;
        }
    }
}
