using E_Commerce_API.Entities;
using E_Commerce_API.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketRipository _basketRipository;
        public BasketController(IBasketRipository basketRipository)
        {
            _basketRipository = basketRipository;   
        }

        [HttpGet]
        public async Task<IActionResult> GetBasketById(string basketId)
        {
            var basket = await _basketRipository.GetBasketAsync(basketId);
            return Ok(basket);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBasket(Basket basket)
        {
            var updatedBasket = await _basketRipository.UpdateBasketAsync(basket);
            return Ok(updatedBasket);
        }

        [HttpDelete]
        public async Task DeleteBasket(string basketId)
        {
            await _basketRipository.DeleteBasketAsync(basketId);
        }
    }
}
