using Microsoft.EntityFrameworkCore;
using SoftwareShop.Discount.Entities;

namespace SoftwareShop.Discount.Context
{
    public class DiscountDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Localde çalışıyorum şuan burası kendine göre ayarla en son dockerla bağlantısını yaparız
            optionsBuilder.UseSqlServer("Data Source=MSA;database=SoftwareShop;Integrated Security=True;TrustServerCertificate=True;");
        }
        public DbSet<Coupon> Coupons { get; set; }
    }
}
