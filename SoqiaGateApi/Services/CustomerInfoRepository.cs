using Microsoft.EntityFrameworkCore;
using SoqiaGateApi.DbContexts;
using SoqiaGateApi.Entities;

namespace SoqiaGateApi.Services
{
    public class CustomerInfoRepository : ICustomerInfoRepository
    {
        private readonly CustomerInfoContext _context;
        public CustomerInfoRepository(CustomerInfoContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }


        //Customers

        public async Task<IEnumerable<Customer>> GetCustomersAsync()
        {
            return await _context.Customers.OrderBy(c => c.FirstName).ToListAsync();
        }


        public async Task<IEnumerable<Customer>> GetCustomersAsync
            (string? firstname, string? searchQuery , int pagenumber , int pagesize)
        {

            var collection = _context.Customers as IQueryable<Customer>;
            if (!string.IsNullOrWhiteSpace(searchQuery))
            {
                searchQuery = searchQuery.Trim();
                collection = collection.Where(c => c.FirstName.Contains(searchQuery) || c.LastName.Contains(searchQuery) || c.NationalId.Contains(searchQuery) );
               
            }
            return await collection.OrderBy(c => c.FirstName)
                .Skip((pagenumber - 1) * pagesize).Take(pagesize)
                .ToListAsync();

        }





        public async Task<Customer?> GetCustomerAsync(int customerId, bool includeCustomerHouses, bool includeWaterOrders)
        {
            if (includeCustomerHouses && !includeWaterOrders)
            {
                return await _context.Customers
                    .Include(c => c.House)
                    .FirstOrDefaultAsync(c => c.CustomerId == customerId);
            }
            else if (includeWaterOrders && !includeCustomerHouses)
            {
                return await _context.Customers
                    .Include(c => c.WaterOrders)
                    .FirstOrDefaultAsync(c => c.CustomerId == customerId);
            }
            else if (includeCustomerHouses && includeWaterOrders)
            {
                return await _context.Customers
                   .Include(c => c.House)
                   .Include(c => c.WaterOrders)
                   .FirstOrDefaultAsync(c => c.CustomerId == customerId);
            }
            else
            {
                return await _context.Customers
                    .FirstOrDefaultAsync(c => c.CustomerId == customerId);
            }
        }


        public async Task<bool> CustomerExistAsync (int customerId)
        {
            return await _context.Customers.AnyAsync(c => c.CustomerId == customerId);
        }

        public async Task AddCustomerAsync(Customer customerEntity)
        {
            await _context.Customers.AddAsync(customerEntity);
            await _context.SaveChangesAsync();
        }


        public void DeleteCustomer(Customer customerEntity)
        {
            _context.Customers.Remove(customerEntity);
        }





        // Customer Houses






        public async Task<IEnumerable<CustomerHouse>> GetCustomerHousesAsync(int customerId)
        {
            return await _context.CustomerHouses.Where(h => h.CustomerId == customerId).ToListAsync();
        }

        public async Task<CustomerHouse?> GetCustomerHouseAsync(int customerId, int houseId)
        {
            return await _context.CustomerHouses.FirstOrDefaultAsync(h => h.CustomerId == customerId && h.CustomerHouseId == houseId);
        }

        public async Task AddCustomerHouse(int customerId, CustomerHouse customerHouseEntity)
        {
            var customer = await GetCustomerAsync(customerId, false, false);
            if (customer != null)
            {
                customer.House?.Add(customerHouseEntity);

            }
          
        }

        public void DeleteCustomerHouse(CustomerHouse customerhouseentity)
        {
            _context.CustomerHouses.Remove(customerhouseentity);
        }

        // Water Orders

        public async Task<IEnumerable<WaterOrder>> GetWaterOrdersAsync(int customerId)
        {
            return await _context.WaterOrders.Where(o => o.CustomerId == customerId).ToListAsync();
        }

        public async Task<WaterOrder?> GetWaterOrderAsync(int customerId, int waterOrderId)
        {
            return await _context.WaterOrders.FirstOrDefaultAsync(o => o.CustomerId == customerId && o.OrderId == waterOrderId);
        }

        public async Task AddWaterOrder(int customerId, WaterOrder waterOrderEntity)
        {
            var customer = await GetCustomerAsync(customerId, false, false);
            if (customer != null)
            {
                customer.WaterOrders?.Add(waterOrderEntity);
            }
        }

        public void DeleteWaterOrder(WaterOrder waterOrderEntity)
        {
            _context.WaterOrders.Remove(waterOrderEntity);
        }


        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }

    }

}

