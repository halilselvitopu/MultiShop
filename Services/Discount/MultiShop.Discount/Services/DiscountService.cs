using Dapper;
using MultiShop.Discount.Context;
using MultiShop.Discount.Dtos.DiscountCouponDtos;

namespace MultiShop.Discount.Services
{
    public class DiscountService : IDiscountService
    {
        private readonly DapperContext _context;

        public DiscountService(DapperContext context)
        {
            _context = context;
        }

        public async Task CreateDiscountCouponAsync(CreateDiscountCouponDto createDiscountCouponDto)
        {
            string query = "INSERT INTO Coupons (Code, DiscountRate, IsActive, ValidDate) VALUES (@Code, @DiscountRate, @IsActive, @ValidDate)";
            var parameters = new DynamicParameters();
            parameters.Add("@Code", createDiscountCouponDto.Code);
            parameters.Add("@DiscountRate", createDiscountCouponDto.DiscountRate);
            parameters.Add("@IsActive", createDiscountCouponDto.IsActive);
            parameters.Add("@ValidDate", createDiscountCouponDto.ValidDate);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
            
        }

        public async Task DeleteDiscountCouponAsync(int id)
        {
            string query = "DELETE FROM Coupons WHERE Id = @Id";
            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultDiscountCouponDto>> GetAllDiscountCouponsAsync()
        {
            string query = "SELECT * FROM Coupons";
            using (var connection = _context.CreateConnection())
            {
                var coupons = await connection.QueryAsync<ResultDiscountCouponDto>(query);
                return coupons.ToList();
            }

        }

        public async Task<GetDiscountCouponByIdDto> GetDiscountCouponByIdAsync(int id)
        {
            string query = "SELECT * FROM Coupons WHERE Id = @Id";
            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);
            using (var connection = _context.CreateConnection())
            {
                return await connection.QueryFirstOrDefaultAsync<GetDiscountCouponByIdDto>(query, parameters);
            }
        }

        public async Task UpdateDiscountCouponAsync(UpdateDiscountCouponDto updateDiscountCoupontDto)
        {
            string query = "UPDATE Coupons SET Code = @Code, DiscountRate = @DiscountRate, IsActive = @IsActive, ValidDate = @ValidDate WHERE Id = @Id";
            var parameters = new DynamicParameters();
            parameters.Add("@Id", updateDiscountCoupontDto.Id);
            parameters.Add("@Code", updateDiscountCoupontDto.Code);
            parameters.Add("@DiscountRate", updateDiscountCoupontDto.DiscountRate);
            parameters.Add("@IsActive", updateDiscountCoupontDto.IsActive);
            parameters.Add("@ValidDate", updateDiscountCoupontDto.ValidDate);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
