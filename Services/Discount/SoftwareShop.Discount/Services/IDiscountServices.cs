using SoftwareShop.Discount.Dtos.DiscountDtos;
using SoftwareShop.Discount.Entities;

namespace SoftwareShop.Discount.Services
{
    public interface IDiscountServices
    {
        Task<List<ResultCouponDto>> GetAllCoupons();
        Task<GetByIdCouponDto> GetByIdCoupon(int id);
        Task CreateCoupon(CreateCouponDto dto);
        Task UpdateCoupon(UpdateCouponDto dto);
        Task DeleteCoupon(int id);
    }
}
