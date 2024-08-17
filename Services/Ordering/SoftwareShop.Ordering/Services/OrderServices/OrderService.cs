using SoftwareShop.Ordering.Dtos.OrderDtos;
using SoftwareShop.Ordering.Entites;
using SoftwareShop.Ordering.Repositories;
using System.Linq.Expressions;

namespace SoftwareShop.Ordering.Services.OrderServices
{
    public class OrderService : IOrderService
    {
        private readonly IRepository<Order> _orderRepository;

        public OrderService(IRepository<Order> orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task CreateOrder(CreateOrderDto dto)
        {
            Order order = new Order 
            {
                OrderDate = dto.OrderDate,
                OrderNumber = dto.OrderNumber,
                Username = dto.Username,
                Usersurname = dto.Usersurname,
                Useremail = dto.Useremail,
                Userphone = dto.Userphone,
                UserId = dto.UserId,
                ProductId = dto.ProductId,
                ProductName = dto.ProductName,
                ProductPrice = dto.ProductPrice,
            };
            await _orderRepository.CreateAsync(order);
        }

        public async Task DeleteOrder(int id)
        {
            var value = await _orderRepository.GetByIdAsync(id);
            await _orderRepository.DeleteAsync(value);
        }

        public async Task<List<ResultOrderDto>> GetAllOrders()
        {
            var value = await _orderRepository.GetAllAsync();
            return value.Select(dto => new ResultOrderDto
            {
                OrderId= dto.OrderId,
                OrderDate = dto.OrderDate,
                OrderNumber = dto.OrderNumber,
                Username = dto.Username,
                Usersurname = dto.Usersurname,
                Useremail = dto.Useremail,
                Userphone = dto.Userphone,
                UserId = dto.UserId,
                ProductId = dto.ProductId,
                ProductName = dto.ProductName,
                ProductPrice = dto.ProductPrice,
            }).ToList();
        }

        public async Task<GetByIdOrderDto> GetByIdOrder(int id)
        {
            var dto = await _orderRepository.GetByIdAsync(id);
            return new GetByIdOrderDto
            {
                OrderId = dto.OrderId,
                OrderDate = dto.OrderDate,
                OrderNumber = dto.OrderNumber,
                Username = dto.Username,
                Usersurname = dto.Usersurname,
                Useremail = dto.Useremail,
                Userphone = dto.Userphone,
                UserId = dto.UserId,
                ProductId = dto.ProductId,
                ProductName = dto.ProductName,
                ProductPrice = dto.ProductPrice,
            };
        }

        public async Task<List<ResultOrderDto>> GetByUserIdOrder(string userId)
        {
            Expression<Func<Order, bool>> filter = p => p.UserId == userId;
            var values = await _orderRepository.WhereAsync(filter);
            return values.Select(dto => new ResultOrderDto
            {
                OrderId = dto.OrderId,
                OrderDate = dto.OrderDate,
                OrderNumber = dto.OrderNumber,
                Username = dto.Username,
                Usersurname = dto.Usersurname,
                Useremail = dto.Useremail,
                Userphone = dto.Userphone,
                UserId = dto.UserId,
                ProductId = dto.ProductId,
                ProductName = dto.ProductName,
                ProductPrice = dto.ProductPrice,
            }).ToList();
        }

        public async Task UpdateOrder(UpdateOrderDto dto)
        {
            var value = await _orderRepository.GetByIdAsync(dto.OrderId);
            value.OrderNumber = dto.OrderNumber;
            value.Username = dto.Username;
            value.Usersurname = dto.Usersurname;
            value.Useremail = dto.Useremail;
            value.Userphone = dto.Userphone;
            value.UserId = dto.UserId;
            value.ProductId = dto.ProductId;
            value.ProductName = dto.ProductName;
            value.ProductPrice = dto.ProductPrice;
            await _orderRepository.UpdateAsync(value);
        }
    }
}
