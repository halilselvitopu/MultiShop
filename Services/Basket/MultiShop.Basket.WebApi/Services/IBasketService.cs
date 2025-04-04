using MultiShop.Basket.WebApi.Dtos;

namespace MultiShop.Basket.WebApi.Services
{
    public interface IBasketService
    {
        Task<BasketTotalDto> GetBasketAsync(string userId);
        Task SaveBasketAsync(BasketTotalDto basketTotalDto);
        Task DeleteBasketAsync(string userId);
    }
}
