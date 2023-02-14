using CarRental.Areas.Identity.Data;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace CarRental.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string Email => User.Email ?? string.Empty;
        [Required]
        public string Phone { get; set; }
        [Required]
        public string LicenseNumber { get; set; }

        // Foreign key to User model
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
