using AutoMapper;
using E_Commerce_API.DTOS;
using E_Commerce_API.Entities.Order;
using E_Commerce_API.Extensions;
using E_Commerce_API.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace E_Commerce_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;
        public OrderController(IOrderService orderService,IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;   
        }

        [HttpGet("GetUserOrders")]
        public async Task<ActionResult<IReadOnlyList<OrderReturnDto>>> GetUserOrders()
        {
            var email = HttpContext.User?.RetrieveEmailFromPrinciple();
            var orders = await _orderService.GetUserOrdersAsync(email);
            var result = _mapper.Map<IReadOnlyList<OrderReturnDto>>(orders);
            return Ok(result);

        }
         

        [HttpGet("GetUserOrdersById")]
        public async Task<ActionResult<OrderReturnDto>> GetUserOrdersById([Required]int id)
        {
            var email = HttpContext.User?.RetrieveEmailFromPrinciple();
            var order = await _orderService.GetOrderByIdAsync(id,email);
            if (order == null) return BadRequest();

            return Ok(order);

        }

        [HttpGet("DeliveryMethod")]
        public async Task<ActionResult<IReadOnlyList<DeliveryMethod>>> DeliveryMethod()
        {
            var allMethods = await _orderService.GetDeliveryMethodAsync();

            return Ok(allMethods);

        }


        [HttpPost("MakeOrder")]
        public async Task<ActionResult<OrderDto>> MakeOrder(OrderDto dto)
        {
            var email = HttpContext.User?.RetrieveEmailFromPrinciple();
            var address = _mapper.Map<AddressDto, address>(dto.ShipToAddress);
            var order = await _orderService.CreateOrderAsync(dto.DeleveryMethodId, dto.BasketId, email , address);

            if (order == null) return BadRequest("Somthing error while make order!");
            return Ok(order);

        }

    }
}
