using System.ComponentModel.DataAnnotations;

namespace CarRental.Models
{
    public class Car
    {
        public int Id { get; set; }
        [Required]
        [StringLength(30, ErrorMessage = "Too long brand name")]
        public string? Brand { get; set; }
        [Required]
        [StringLength(255, ErrorMessage = "Too long model name")]
        public string? Model { get; set; }
        [Required]
        public int Year { get; set; }
        [Required]
        [Display(Name = "Price per day")]
        public int DailyRate { get; set; }
        [Display(Name = "Is Available")]
        public bool IsAvailable { get; set; }
        [Display(Name = "Image of a car")]
        public string? ImageUrl { get; set; }
    }
}