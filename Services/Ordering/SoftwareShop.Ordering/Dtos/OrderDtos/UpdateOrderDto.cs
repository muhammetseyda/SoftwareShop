using SoftwareShop.Ordering.Entites;

namespace SoftwareShop.Ordering.Dtos.OrderDtos
{
    public class UpdateOrderDto
    {
        public int OrderId { get; set; }
        public string OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public string UserId { get; set; }
        public string Username { get; set; }
        public string Usersurname { get; set; }
        public string Useremail { get; set; }
        public string Userphone { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductPrice { get; set; }
    }
}
