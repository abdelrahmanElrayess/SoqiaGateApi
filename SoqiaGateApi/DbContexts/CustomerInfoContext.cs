using Microsoft.EntityFrameworkCore;
using SoqiaGateApi.Entities;
using SoqiaGateApi.Models;

namespace SoqiaGateApi.DbContexts
{
    public class CustomerInfoContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerHouse> CustomerHouses { get; set; }
        public DbSet<WaterOrder> WaterOrders { get; set; }

        public CustomerInfoContext(DbContextOptions<CustomerInfoContext> options) : base(options)
        {
            //Database.EnsureCreated();
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
      .HasData(
          new Customer
          {
              CustomerId = 1,
              NationalId = "1234567890",
              FamilySize = 3,
              FirstName = "John",
              FatherName = "Doe",
              LastName = "Smith",
              GrandfatherName = "Johnson", // add a value for GrandfatherName
              Email = "john.doe@example.com",
              PhoneNumber = "555-1234",
              MobileNumber = "555-5678",
              POBox = "1234",
              PostalCode = "10001"
          },
          new Customer
          {
              CustomerId = 2,
              NationalId = "0987654321",
              FamilySize = 4,
              FirstName = "Jane",
              FatherName = "Doe",
              LastName = "Johnson",
              GrandfatherName = "Smith", // add a value for GrandfatherName
              Email = "jane.doe@example.com",
              PhoneNumber = "555-4321",
              MobileNumber = "555-8765",
              POBox = "5678",
              PostalCode = "10002"
          },
          new Customer
          {
              CustomerId = 3,
              NationalId = "1357924680",
              FamilySize = 2,
              FirstName = "Bob",
              FatherName = "Smith",
              LastName = "Johnson",
              GrandfatherName = "Doe", // add a value for GrandfatherName
              Email = "bob.smith@example.com",
              PhoneNumber = "555-2468",
              MobileNumber = "555-1357",
              POBox = "9012",
              PostalCode = "10003"
          }
      );
            modelBuilder.Entity<CustomerHouse>()
                 .HasData(
                     new CustomerHouse
                     {
                         CustomerHouseId = 1,
                         PlotNumber = 123,
                         LandNumber = 456,
                         LandArea = 250.5,
                         BuildingArea = 150.2,
                         ConnectionNumber = 789,
                         ElectricitySubscriptionNumber = 101112,
                         PropertyType = "Residential",
                         Address = "123 Main St",
                         Coordinates = "40.7128,-74.0060",
                         RequestType = "new",
                         CustomerId = 1
                     },
                     new CustomerHouse
                     {
                         CustomerHouseId = 2,
                         PlotNumber = 456,
                         LandNumber = 789,
                         LandArea = 450.2,
                         BuildingArea = 300.8,
                         ConnectionNumber = 101,
                         ElectricitySubscriptionNumber = 131415,
                         PropertyType = "Commercial",
                         Address = "456 Broadway",
                         Coordinates = "40.7214,-74.0052",
                         RequestType = "new",
                         CustomerId = 2
                     },
                     new CustomerHouse
                     {
                         CustomerHouseId = 3,
                         PlotNumber = 789,
                         LandNumber = 123,
                         LandArea = 300.0,
                         BuildingArea = 200.5,
                         ConnectionNumber = 161,
                         ElectricitySubscriptionNumber = 161718,
                         PropertyType = "Residential",
                         Address = "789 Elm St",
                         Coordinates = "40.7069,-73.9969",
                         RequestType = "Upgrade",
                         CustomerId = 3
                     }
                 );


            modelBuilder.Entity<WaterOrder>()
                .HasData(
                    new WaterOrder
                    {
                        OrderId = 1,
                        OrderDate = new DateTime(2023, 4, 10, 13, 30, 0),
                        DeliveryAddress = "123 Main St",
                        ContactNumber = "555-1234",
                        Status = Entities.OrderStatus.Waiting,
                        CustomerId = 1
                    },
                    new WaterOrder
                    {
                        OrderId = 2,
                        OrderDate = new DateTime(2023, 4, 9, 10, 0, 0),
                        DeliveryAddress = "456 Broadway",
                        ContactNumber = "555-5678",
                        Status = Entities.OrderStatus.Approved,
                        CustomerId = 2
                    },
                    new WaterOrder
                    {
                        OrderId = 3,
                        OrderDate = new DateTime(2023, 4, 8, 15, 45, 0),
                        DeliveryAddress = "789 Elm St",
                        ContactNumber = "555-9012",
                        Status = Entities.OrderStatus.Rejected,
                        CustomerId = 3
                    }
                );


            base.OnModelCreating(modelBuilder);
        }
    }
}
