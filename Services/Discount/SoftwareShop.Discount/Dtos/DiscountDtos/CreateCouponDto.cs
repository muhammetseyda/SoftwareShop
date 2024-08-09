namespace SoftwareShop.Discount.Dtos.DiscountDtos
{
    public class CreateCouponDto
    {
        public string Code { get; set; }
        public int Rate { get; set; }
        public bool isActive { get; set; }
        public DateTime ValidDate { get; set; }
    }
}
