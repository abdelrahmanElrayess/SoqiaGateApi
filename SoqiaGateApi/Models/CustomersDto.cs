namespace SoqiaGateApi.Models
{
    public class CustomersDto
    {
        public int CustomerId { get; set; }
        public string? NationalId { get; set; }
        public int FamilySize { get; set; }
        public string? FirstName { get; set; }
        public string? FatherName { get; set; }
        public string? GrandfatherName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? MobileNumber { get; set; }
        public string? POBox { get; set; }
        public string? PostalCode { get; set; }


        public virtual ICollection<CustomersHouseDto>? House { get; set; } =
            new List<CustomersHouseDto>();

        public virtual ICollection<WaterOrderDto>? WaterOrders { get; set; } =
            new List<WaterOrderDto>();

    }
}
