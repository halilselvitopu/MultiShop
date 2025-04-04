using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Basket.WebApi.Dtos;
using MultiShop.Basket.WebApi.LoginServices;
using MultiShop.Basket.WebApi.Services;

namespace MultiShop.Basket.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketsController : ControllerBase
    {
        private readonly IBasketService _basketService;
        private readonly ILoginService _loginService;

        public BasketsController(IBasketService basketService, ILoginService loginService)
        {
            _basketService = basketService;
            _loginService = loginService;
        }

        [HttpGet]
        public async Task<IActionResult> GetBasket()
        {
            var user = User.Claims;
            var userId = _loginService.GetUserId;
            var values = await _basketService.GetBasketAsync(userId);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> SaveBasket(BasketTotalDto basketTotalDto)
        {
            var userId = _loginService.GetUserId;
            basketTotalDto.UserId = userId;
            await _basketService.SaveBasketAsync(basketTotalDto);
            return Ok("Sepetteki değişikler kaydedildi.");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteBasket()
        {
            var userId = _loginService.GetUserId;
            await _basketService.DeleteBasketAsync(userId);
            return Ok("Sepetiniz silindi.");
        }
    }
}
