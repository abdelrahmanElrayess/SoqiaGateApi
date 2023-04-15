namespace SoqiaGateApi.Models
{
    public class WaterOrderForUpdate
    {
        public DateTime OrderDate { get; set; }
        public string? DeliveryAddress { get; set; }
        public string? ContactNumber { get; set; }
        public int CustomerId { get; set; }
        public CustomersDto? Customer { get; set; }
        public OrderStatus Status { get; set; }
    }
}
