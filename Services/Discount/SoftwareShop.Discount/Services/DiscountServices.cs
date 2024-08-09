using Microsoft.EntityFrameworkCore;
using SoftwareShop.Discount.Context;
using SoftwareShop.Discount.Dtos.DiscountDtos;
using SoftwareShop.Discount.Entities;
using SoftwareShop.Discount.Repositories;

namespace SoftwareShop.Discount.Services
{
    public class DiscountServices : IDiscountServices
    {
        private readonly IRepository<Coupon> _repository;

        public DiscountServices(IRepository<Coupon> repository)
        {
            _repository = repository;
        }

        public async Task CreateCoupon(CreateCouponDto dto)
        {
            Coupon coupon = new Coupon
            {
                 Code = dto.Code,
                 isActive = dto.isActive,
                 Rate = dto.Rate,
                 ValidDate = dto.ValidDate,
            };
            await _repository.CreateAsync(coupon);
        }

        public async Task DeleteCoupon(int id)
        {
            var value = await _repository.GetByIdAsync(id);
            await _repository.DeleteAsync(value);

        }

        public async Task<List<ResultCouponDto>> GetAllCoupons()
        {
            var value = await _repository.GetAllAsync();
            return value.Select(x => new ResultCouponDto{
                isActive = x.isActive,
                Rate = x.Rate,
                ValidDate = x.ValidDate,
                Code = x.Code,
                CouponId = x.CouponId,
            }).ToList();
        }

        public async Task<GetByIdCouponDto> GetByIdCoupon(int id)
        {
            var value = await _repository.GetByIdAsync(id);
            return new GetByIdCouponDto 
            {
                CouponId = value.CouponId,
                Code = value.Code,
                Rate = value.Rate,
                ValidDate = value.ValidDate,
                isActive = value.isActive,
            };
        }

        public async Task UpdateCoupon(UpdateCouponDto dto)
        {
            var value = await _repository.GetByIdAsync(dto.CouponId);
            value.ValidDate = dto.ValidDate;
            value.Code = dto.Code;
            value.Rate = dto.Rate;
            value.isActive = dto.isActive;
            await _repository.UpdateAsync(value);
        }
    }
}
