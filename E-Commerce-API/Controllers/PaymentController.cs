using E_Commerce_API.Entities;
using E_Commerce_API.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;
        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpPost("CreateOrUpdatePayment")]
        public async Task<ActionResult<Basket>> CreateOrUpdatePayment(string basketId)
        {
            var basket = await _paymentService.CreateOrUpdatePayment(basketId);
            if (basket == null) return BadRequest();
            return basket;
        }
    }
}
