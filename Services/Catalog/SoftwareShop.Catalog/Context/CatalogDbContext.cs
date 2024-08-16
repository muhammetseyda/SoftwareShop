using Microsoft.EntityFrameworkCore;
using SoftwareShop.Catalog.Entities;

namespace SoftwareShop.Catalog.Context
{
    public class CatalogDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Localde çalışıyorum şuan burası kendine göre ayarla en son dockerla bağlantısını yaparız
            optionsBuilder.UseSqlServer("Data Source=MSA;database=SoftwareShop;Integrated Security=True;TrustServerCertificate=True;");
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
