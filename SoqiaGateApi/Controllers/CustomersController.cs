using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using SoqiaGateApi.Entities;
using SoqiaGateApi.Models;
using SoqiaGateApi.Services;

namespace SoqiaGateApi.Controllers
{
    [ApiController]
   
    [Route ("api/Customers")]

    public class CustomersController : ControllerBase
    {


        private readonly ICustomerInfoRepository _customerInfoRepository;
        private readonly IMapper _mapper;
        const int maxCustomersPageSize = 20;
        public CustomersController(ICustomerInfoRepository customerInfoRepository , IMapper mapper)
        {
            _customerInfoRepository = customerInfoRepository ?? throw new ArgumentNullException(nameof(customerInfoRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }




      
        

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomersDto>>> GetCustomers(string? FirstName , string? searchQuery, int pageNumber = 1, int pageSize = 10)
        {

            if (pageNumber < 1)
            {
                return BadRequest();
            }

            if (pageSize > maxCustomersPageSize)
            {
                pageSize = maxCustomersPageSize;
            }




            var customersFromRepo = await _customerInfoRepository
                .GetCustomersAsync(FirstName , searchQuery , pageNumber, pageSize);

            return Ok(_mapper.Map<IEnumerable<CustomerDtoEmpty>>(customersFromRepo));
        }   






        [HttpGet("id/{id}")]

        public async Task<IActionResult> GetCustomer(int id, bool includeCustomerHouses = false, bool includeWaterOrders = false)
        {
            var customer = await _customerInfoRepository.GetCustomerAsync(id, includeCustomerHouses, includeWaterOrders);

            if (customer == null)
            {
                return NotFound();
            }


            return Ok(_mapper.Map<CustomersDto>(customer));
        }



        [HttpPost]
        public async Task<ActionResult<CustomersDto>> CreateCustomer([FromBody] CustomerForCreation customer)
        {
            if (customer == null)
            {
                return BadRequest();
            }
            var customerEntity = _mapper.Map<Customer>(customer);

            await _customerInfoRepository.AddCustomerAsync(customerEntity);

            await _customerInfoRepository.SaveChangesAsync();

            var customerToReturn = _mapper.Map<CustomersDto>(customerEntity);

            return CreatedAtRoute( new { id = customerToReturn.CustomerId }, customerToReturn);
        }


     

        [HttpPut("{CustomerId}")]
        public async Task<IActionResult> UpdateCustomer(int CustomerId, [FromBody] CustomerForUpdate customer)
        {
            if (customer == null)
            {
                return BadRequest();
            }
            var customerFromRepo = await _customerInfoRepository.GetCustomerAsync(CustomerId, IncludeCustomerHouses: false, IncludeWaterOrders: false);
            if (customerFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(customer, customerFromRepo);
            await _customerInfoRepository.SaveChangesAsync();
            return NoContent();
        }
      


        [HttpPatch("{customerId}")]
        public async Task<ActionResult> PartiallyUpdateCustomer
            (int customerId, [FromBody] JsonPatchDocument<CustomerForUpdate> patchDoc)
        {
            if (!await _customerInfoRepository.CustomerExistAsync(customerId))
            {
                return NotFound();
            }



            var customerFromRepo = await _customerInfoRepository.GetCustomerAsync(customerId, IncludeCustomerHouses: false, IncludeWaterOrders: false);
            if (customerFromRepo == null)
            {
                return NotFound();
            }

            var customerToPatch = _mapper.Map<CustomerForUpdate>(customerFromRepo);

            patchDoc.ApplyTo(customerToPatch, ModelState);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!TryValidateModel(customerToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(customerToPatch, customerFromRepo);

            await _customerInfoRepository.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{CustomerId}")]
        public async Task<ActionResult> DeleteCustomer(int CustomerId)
        {
            if (!await _customerInfoRepository.CustomerExistAsync(CustomerId))
            {
                return NotFound();
            }
            var customerFromRepo = await _customerInfoRepository.GetCustomerAsync(CustomerId, IncludeCustomerHouses: false, IncludeWaterOrders: false);
            if (customerFromRepo == null)
            {
                return NotFound();
            }
            _customerInfoRepository.DeleteCustomer(customerFromRepo);
            await _customerInfoRepository.SaveChangesAsync();
            return NoContent();
        }
        



    }
}