using SoqiaGateApi.Entities;

namespace SoqiaGateApi.Services
{
    public interface ICustomerInfoRepository
    {
        //customer
        Task<IEnumerable<Customer>> GetCustomersAsync();
        Task<IEnumerable<Customer>> GetCustomersAsync(string? FirstName , string? searchQuery , int pagenumber , int pagesize );
        Task<Customer?> GetCustomerAsync(int CustomerId, bool IncludeCustomerHouses, bool IncludeWaterOrders);

        Task<bool> CustomerExistAsync(int customerId);
        Task AddCustomerAsync(Customer customerEntity);
        void DeleteCustomer(Customer customerEntity);


        //customerhouse
        Task<IEnumerable<CustomerHouse>> GetCustomerHousesAsync(int CustomerId);
 
        Task<CustomerHouse?> GetCustomerHouseAsync(int CustomerId, int HouseId);
        Task AddCustomerHouse(int customerId, CustomerHouse customerHouseEntity);
        void DeleteCustomerHouse(CustomerHouse customerhouseentity);

        //waterorder
        Task<IEnumerable<WaterOrder>> GetWaterOrdersAsync(int CustomerId);
        Task<WaterOrder?> GetWaterOrderAsync(int CustomerId, int WaterOrderId);
        Task AddWaterOrder(int customerId, WaterOrder waterOrderEntity);
        void DeleteWaterOrder(WaterOrder waterOrderEntity);

        // general

        Task<bool> SaveChangesAsync ();
       
    }
} 
