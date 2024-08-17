using SoftwareShop.Ordering.Dtos.OrderDtos;
using SoftwareShop.Ordering.Entites;
using SoftwareShop.Ordering.Repositories;

namespace SoftwareShop.Ordering.Services.OrderServices
{
    public interface IOrderService
    {
        Task<List<ResultOrderDto>> GetAllOrders();
        Task<GetByIdOrderDto> GetByIdOrder(int id);
        Task CreateOrder(CreateOrderDto dto);
        Task UpdateOrder(UpdateOrderDto dto);
        Task DeleteOrder(int id);
        Task<List<ResultOrderDto>> GetByUserIdOrder(string userId);
    }
}
