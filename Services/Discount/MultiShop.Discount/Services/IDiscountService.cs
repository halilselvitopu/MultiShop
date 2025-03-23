using MultiShop.Discount.Dtos.DiscountCouponDtos;

namespace MultiShop.Discount.Services
{
    public interface IDiscountService
    {
        Task<List<ResultDiscountCouponDto>> GetAllDiscountCouponsAsync();
        Task CreateDiscountCouponAsync(CreateDiscountCouponDto createDiscountCouponDto);
        Task UpdateDiscountCouponAsync(UpdateDiscountCouponDto updateDiscountCoupontDto);
        Task DeleteDiscountCouponAsync(int id);
        Task<GetDiscountCouponByIdDto> GetDiscountCouponByIdAsync(int id);
    }
}
