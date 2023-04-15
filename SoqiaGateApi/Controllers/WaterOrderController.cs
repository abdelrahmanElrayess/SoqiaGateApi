using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using SoqiaGateApi.Models;
using SoqiaGateApi.Services;

namespace SoqiaGateApi.Controllers
{
    [Route("api/Customers/{CustomerId}/Order")]
    [ApiController]
    public class WaterOrderController : ControllerBase
    {
        private readonly ICustomerInfoRepository _customerInfoRepository;
        private readonly IMapper _mapper;
        public WaterOrderController(ICustomerInfoRepository customerInfoRepository, IMapper mapper)
        {
            _customerInfoRepository = customerInfoRepository ?? throw new ArgumentNullException(nameof(customerInfoRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }







        [HttpGet]
        //get water orders from repository async
        public async Task<ActionResult<IEnumerable<WaterOrderDto>>> GetWaterOrders(int CustomerId)
        {
            if (!await _customerInfoRepository.CustomerExistAsync(CustomerId))
            {
                return NotFound();
            }
            var waterOrders = await _customerInfoRepository.GetWaterOrdersAsync(CustomerId);
            return Ok(_mapper.Map<IEnumerable<WaterOrderDto>>(waterOrders));
        }
       


        [HttpGet("{orderId}", Name = "GetWaterOrder")]
        public async Task<ActionResult<WaterOrderDto>> GetWaterOrder(int CustomerId, int orderId)
        {
            if (!await _customerInfoRepository.CustomerExistAsync(CustomerId))
            {
                return NotFound();
            }
            var waterOrder = await _customerInfoRepository.GetWaterOrderAsync(CustomerId, orderId);
            if (waterOrder == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<WaterOrderDto>(waterOrder));
        }
      

        [HttpPost]


        public async Task<ActionResult<WaterOrderDto>> CreateWaterOrder(int CustomerId, WaterOrderForCreation waterOrder)
        {
            if (!await _customerInfoRepository.CustomerExistAsync(CustomerId))
            {
                return NotFound();
            }
            var waterOrderEntity = _mapper.Map<Entities.WaterOrder>(waterOrder);

            await _customerInfoRepository.AddWaterOrder(CustomerId, waterOrderEntity);

            await _customerInfoRepository.SaveChangesAsync();

            var waterOrderToReturn = _mapper.Map<WaterOrderDto>(waterOrderEntity);

            return CreatedAtRoute("GetWaterOrder", new { CustomerId = CustomerId, orderId = waterOrderToReturn.OrderId }, waterOrderToReturn);
        }

        [HttpPatch("{OrderId}")]
        public async Task<IActionResult> PartiallyUpdateWaterOrder(int CustomerId, int OrderId, JsonPatchDocument<WaterOrderForUpdate> patchDocument)
        {
            if (!await _customerInfoRepository.CustomerExistAsync(CustomerId))
            {
                return NotFound();
            }


            var waterOrderFromRepo = await _customerInfoRepository.GetWaterOrderAsync(CustomerId, OrderId);

            if (waterOrderFromRepo == null)
            {
                return NotFound();
            }

            var waterOrderToPatch = _mapper.Map<WaterOrderForUpdate>(waterOrderFromRepo);

            patchDocument.ApplyTo(waterOrderToPatch, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            if (!TryValidateModel(waterOrderToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(waterOrderToPatch, waterOrderFromRepo);

            await _customerInfoRepository.SaveChangesAsync();

            return NoContent();
        }


        [HttpDelete("{OrderId}")]
        public async Task<IActionResult> DeleteWaterOrder(int CustomerId, int OrderId)
        {
            if (!await _customerInfoRepository.CustomerExistAsync(CustomerId))
            {
                return NotFound();
            }
            var waterOrderFromRepo = await _customerInfoRepository.GetWaterOrderAsync(CustomerId, OrderId);
            if (waterOrderFromRepo == null)
            {
                return NotFound();
            }
            _customerInfoRepository.DeleteWaterOrder(waterOrderFromRepo);
            await _customerInfoRepository.SaveChangesAsync();
            return NoContent();
        }

    }
}
