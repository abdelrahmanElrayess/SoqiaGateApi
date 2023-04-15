using SoqiaGateApi.Models;

namespace SoqiaGateApi
{
    public class CustomersDataStore
    {
        public List<CustomersDto>? Customers { get; set; }

        public static CustomersDataStore Current { get; } = new CustomersDataStore();
        public CustomersDataStore() 
        {

            Customers = new List<CustomersDto>()
{
    new CustomersDto
    {
        CustomerId = 1,
        NationalId = "1234567890",
        FamilySize = 3,
        FirstName = "John",
        FatherName = "Doe",
        LastName = "Smith",
        Email = "john.doe@example.com",
        PhoneNumber = "555-1234",
        MobileNumber = "555-5678",
        POBox = "1234",
        PostalCode = "10001",
        House = new List<CustomersHouseDto>()
        {
            new CustomersHouseDto
            {
                HouseId = 1,
                PlotNumber = 1,
                LandNumber = 2,
                LandArea = 100.0,
                BuildingArea = 200.0,
                ConnectionNumber = 1234,
                ElectricitySubscriptionNumber = 5678,
                PropertyType = "Residential",
                Address = "123 Main St",
                Coordinates = "40.7128,-74.0060",
                RequestType = "New"
            }
        },

        WaterOrders =new List<WaterOrderDto>()
        {
            new WaterOrderDto
{
    OrderId = 1,
    OrderDate = new DateTime(2022, 3, 15),
    DeliveryAddress = "123 Main Street",
    ContactNumber = "555-1234",
    Status = OrderStatus.Waiting
},
new WaterOrderDto
{
    OrderId = 2,
    OrderDate = new DateTime(2022, 3, 16),
    DeliveryAddress = "456 Elm Street",
    ContactNumber = "555-5678",
    Status = OrderStatus.Approved
},
new WaterOrderDto
{
    OrderId = 3,
    OrderDate = new DateTime(2022, 3, 17),
    DeliveryAddress = "789 Oak Street",
    ContactNumber = "555-9012",
    Status = OrderStatus.Rejected
}

        }

    }
    
    
    
    ,
    new CustomersDto
    {
        CustomerId = 2,
        NationalId = "0987654321",
        FamilySize = 2,
        FirstName = "Jane",
        FatherName = "Doe",
        LastName = "Johnson",
        Email = "jane.doe@example.com",
        PhoneNumber = "555-5678",
        MobileNumber = "555-1234",
        POBox = "5678",
        PostalCode = "90001",
        House = new List<CustomersHouseDto>()
        {
            new CustomersHouseDto
            {
                HouseId = 2,
                PlotNumber = 2,
                LandNumber = 3,
                LandArea = 150.0,
                BuildingArea = 250.0,
                ConnectionNumber = 5678,
                ElectricitySubscriptionNumber = 1234,
                PropertyType = "Commercial",
                Address = "456 Elm St",
                Coordinates = "34.0522,-118.2437",
                RequestType = "Upgrade"
            }
        }
    }
};

        }
    }
}
