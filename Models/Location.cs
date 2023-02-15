namespace CarRental.Models
{
    public class Location
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        //todo think about deleteing this prop since it won't be used propably
        public virtual ICollection<Car>? Cars { get; set; }
    }
}
