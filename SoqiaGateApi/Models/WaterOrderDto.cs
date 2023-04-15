namespace SoqiaGateApi.Models
{
    public class WaterOrderDto
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public string? DeliveryAddress { get; set; }
        public string? ContactNumber { get; set; }
        public OrderStatus Status { get; set; } 


    }
    public enum OrderStatus
    {
        Waiting,
        Approved,
        Rejected
    }
}
