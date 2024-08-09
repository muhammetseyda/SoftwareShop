using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SoftwareShop.Discount.Dtos.DiscountDtos;
using SoftwareShop.Discount.Services;

namespace SoftwareShop.Discount.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountsController : ControllerBase
    {
        private readonly IDiscountServices _discountService;

        public DiscountsController(IDiscountServices discountService)
        {
            _discountService = discountService;
        }

        [HttpGet]
        public async Task<IActionResult> DiscountCouponList()
        {
            var values = await _discountService.GetAllCoupons();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDiscountCouponById(int id)
        {
            var values = await _discountService.GetByIdCoupon(id);
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateDiscountCoupon(CreateCouponDto createCouponDto)
        {
            await _discountService.CreateCoupon(createCouponDto);
            return Ok("Kupon oluşturuldu");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateDiscountCoupon(UpdateCouponDto updateCouponDto)
        {
            await _discountService.UpdateCoupon(updateCouponDto);
            return Ok("Kupon Güncellendi");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteDiscountCoupon(int id)
        {
            await _discountService.DeleteCoupon(id);
            return Ok("Kupon Silindi");
        }
    }
}
