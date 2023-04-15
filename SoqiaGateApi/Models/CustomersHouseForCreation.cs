using System.ComponentModel.DataAnnotations;

namespace SoqiaGateApi.Models
{
    public class CustomersHouseForCreation
    {
        [Required]
        public int PlotNumber { get; set; }
        [Required]
        public int LandNumber { get; set; }
        [Required]
        public double LandArea { get; set; }
        [Required]
        public double BuildingArea { get; set; }
        [Required]
        public int ConnectionNumber { get; set; }
        [Required]
        public int ElectricitySubscriptionNumber { get; set; }
        [Required]
        public string? PropertyType { get; set; }
        [Required]
        public string? Address { get; set; }
        [Required]
        public string? Coordinates { get; set; }
        [Required]
        public string? RequestType { get; set; }
    }
}
