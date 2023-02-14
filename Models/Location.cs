﻿namespace CarRental.Models
{
    public class Location
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public virtual ICollection<Car> Cars { get; set; }
    }
}
