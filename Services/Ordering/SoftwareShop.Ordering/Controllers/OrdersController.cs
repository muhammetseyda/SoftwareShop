using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SoftwareShop.Ordering.Dtos.OrderDtos;
using SoftwareShop.Ordering.Services.OrderServices;

namespace SoftwareShop.Ordering.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _OrderService;

        public OrdersController(IOrderService OrderService)
        {
            _OrderService = OrderService;
        }
        [HttpGet]
        public async Task<IActionResult> OrderList()
        {
            var values = await _OrderService.GetAllOrders();
            return Ok(values);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetOrderById(int id)
        {
            var values = await _OrderService.GetByIdOrder(id);
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateOrder(CreateOrderDto createOrderDto)
        {
            await _OrderService.CreateOrder(createOrderDto);
            return Ok("Siparis oluşturuldu");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateOrder(UpdateOrderDto updateOrderDto)
        {
            await _OrderService.UpdateOrder(updateOrderDto);
            return Ok("Siparis Güncellendi");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            await _OrderService.DeleteOrder(id);
            return Ok("Siparis Silindi");
        }
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetOrderByUserId(string userId)
        {
            var values = await _OrderService.GetByUserIdOrder(userId);
            return Ok(values);
        }
    }
}
