using Microsoft.EntityFrameworkCore;
using SoftwareShop.Ordering.Entites;

namespace SoftwareShop.Ordering.Context
{
    public class OrderingDbContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Localde çalışıyorum şuan burası kendine göre ayarla en son dockerla bağlantısını yaparız
            optionsBuilder.UseSqlServer("Data Source=MSA;database=SoftwareShop;Integrated Security=True;TrustServerCertificate=True;");
        }
        public DbSet<Order> Orders { get; set; }
    }
}
