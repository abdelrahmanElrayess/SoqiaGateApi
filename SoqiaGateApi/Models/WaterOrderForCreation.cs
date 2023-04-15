using System.ComponentModel.DataAnnotations;

namespace SoqiaGateApi.Models
{
    public class WaterOrderForCreation
    {
      
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public string? DeliveryAddress { get; set; }
        
        public string? ContactNumber { get; set; }
        public OrderStatus Status { get; set; } = OrderStatus.Waiting;

    }
}
