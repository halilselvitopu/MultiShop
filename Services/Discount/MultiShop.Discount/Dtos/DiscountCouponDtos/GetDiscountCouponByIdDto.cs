namespace MultiShop.Discount.Dtos.DiscountCouponDtos
{
    public class GetDiscountCouponByIdDto
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public int DiscountRate { get; set; }
        public bool IsActive { get; set; }
        public DateTime ValidDate { get; set; }
    }
}
