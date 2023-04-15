using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoqiaGateApi.Entities
{
    public class CustomerHouse
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerHouseId { get; set; }
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
        public string? RequestType { get; set; }
        [ForeignKey(nameof(CustomerId))]
        public Customer? Customer { get; set; }
        public int CustomerId { get; set; }
    }
}
