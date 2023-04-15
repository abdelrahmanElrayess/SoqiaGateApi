namespace SoqiaGateApi.Models
{
    public class CustomersHouseDto
    {
        public int HouseId { get; set; }
        public int PlotNumber { get; set; }
        public int LandNumber { get; set; }
        public double LandArea { get; set; }
        public double BuildingArea { get; set; }
        public int ConnectionNumber { get; set; }
        public int ElectricitySubscriptionNumber { get; set; }
        public string? PropertyType { get; set; }
        public string? Address { get; set; }
        public string? Coordinates { get; set; }
        public string? RequestType { get; set; }
        
    }
}
