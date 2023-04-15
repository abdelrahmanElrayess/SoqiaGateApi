using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoqiaGateApi.Entities
{
    public class WaterOrder
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
        [Required]
        public string? DeliveryAddress { get; set; }
        [Required]
        public string? ContactNumber { get; set; }
        public OrderStatus Status { get; set; }
        [ForeignKey(nameof(CustomerId))]
        public Customer? Customer { get; set; }
        public int CustomerId { get; set; }

    }
    public enum OrderStatus
    {
        Waiting = 0 ,
        Approved = 1,
        Rejected = 2
    }
}

