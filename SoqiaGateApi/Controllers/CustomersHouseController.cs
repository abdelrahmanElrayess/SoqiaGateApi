using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SoqiaGateApi.Models;
using SoqiaGateApi.Services;
using SoqiaGateApi.Entities;
using Microsoft.AspNetCore.Authorization;

namespace SoqiaGateApi.Controllers
{
    [Route("api/Customers/{CustomerId}/CustomerHouse")]

    [ApiController]
   
    public class CustomersHouseController : ControllerBase
    {
        //inject the repository
        private readonly ICustomerInfoRepository _customerInfoRepository;
        private readonly IMapper _mapper;
        public CustomersHouseController(ICustomerInfoRepository customerInfoRepository, IMapper mapper)
        {
            _customerInfoRepository = customerInfoRepository ?? throw new ArgumentNullException(nameof(customerInfoRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }   




        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomersHouseDto>>> GetCustomersHouse(int CustomerId)
        {

            if (!await _customerInfoRepository.CustomerExistAsync(CustomerId))
            {
                return NotFound();
            }



            var customerhouse = await _customerInfoRepository.GetCustomerHousesAsync(CustomerId);
        

            return Ok(_mapper.Map<IEnumerable<CustomersHouseDto>>(customerhouse));
        }
     

        [HttpGet("{HouseId}", Name = "CreateCustomerHouse")]
        public async Task<ActionResult<CustomersHouseDto>> GetCustomersHouse(int CustomerId, int HouseId)
        {
            if (!await _customerInfoRepository.CustomerExistAsync(CustomerId))
            {
                return NotFound();
            }
            var customerhouse = await _customerInfoRepository.GetCustomerHouseAsync(CustomerId, HouseId);
            if (customerhouse == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<CustomersHouseDto>(customerhouse));
           
        }

        [HttpPost]
        public async Task<ActionResult<CustomersHouseDto>> CreateCustomerHouse
        (int CustomerId, CustomersHouseForCreation customerhouse)
        {
            if (!await _customerInfoRepository.CustomerExistAsync(CustomerId))
            {
                return NotFound();
            }
            var customerHouseEntity = _mapper.Map<CustomerHouse>(customerhouse);



            await _customerInfoRepository.AddCustomerHouse(CustomerId, customerHouseEntity);
            await _customerInfoRepository.SaveChangesAsync();


            var customerHouseToReturn = _mapper.Map<CustomersHouseDto>(customerHouseEntity);
            return CreatedAtRoute("CreateCustomerHouse",new 
                               { CustomerId = CustomerId,
                                 HouseId = customerHouseToReturn.HouseId },
                                 customerHouseToReturn);
         

        }

        [HttpPut("{HouseId}")]

        public async Task<ActionResult> UpdateCustomerHouse
            (int CustomerId, int HouseId, CustomerHouseForUpdate customerHouseForUpdate)
        {
            if (!await _customerInfoRepository.CustomerExistAsync(CustomerId))
            {
                return NotFound();
            }


            var customerhouseentity = await _customerInfoRepository.GetCustomerHouseAsync(CustomerId, HouseId);
            if (customerhouseentity != null)
            {
                return NotFound();
            }

            _mapper.Map(customerHouseForUpdate, customerhouseentity);

            await _customerInfoRepository.SaveChangesAsync();

            return NoContent();
        }


        [HttpPatch("{HouseId}")]

        public async Task<ActionResult> PartiallyUpdateCustomerHouse
            (int CustomerId, int HouseId , JsonPatchDocument<CustomerHouseForUpdate> patchDocument)
        {
           
            if (!await _customerInfoRepository.CustomerExistAsync(CustomerId))
            {
                return NotFound();
            }

           
            var customerhouseentity = await _customerInfoRepository.GetCustomerHouseAsync(CustomerId, HouseId);
            if (customerhouseentity == null)
            {
                return NotFound();
            }

            var customerHouseToPatch = _mapper.Map<CustomerHouseForUpdate>(customerhouseentity);


            patchDocument.ApplyTo(customerHouseToPatch, ModelState);

            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if(!TryValidateModel(customerHouseToPatch))
            {
                return BadRequest(ModelState);
            }

            _mapper.Map(customerHouseToPatch, customerhouseentity);
            
            await _customerInfoRepository.SaveChangesAsync();

            return NoContent();



        }

        [HttpDelete("{HouseId}")]
        public async Task<ActionResult> DeleteCustomerHouse(int CustomerId, int HouseId)
        {
            if (!await _customerInfoRepository.CustomerExistAsync(CustomerId))
            {
                return NotFound();
            }

            var customerhouseentity = await _customerInfoRepository.GetCustomerHouseAsync(CustomerId, HouseId);
            if (customerhouseentity == null)
            {
                return NotFound();
            }

            _customerInfoRepository.DeleteCustomerHouse(customerhouseentity);
            await _customerInfoRepository.SaveChangesAsync();
            return NoContent();
        }


    }
}
