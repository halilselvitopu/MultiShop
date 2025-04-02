namespace MultiShop.Basket.WebApi.Dtos
{
    public class BasketItemDto
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public int ProductAmount { get; set; }
        public decimal Price { get; set; }
    }
}
