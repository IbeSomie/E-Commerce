using ECommerceWebsite.Data;
using ECommerceWebsite.DTOs.CategoryDto;
using ECommerceWebsite.DTOs.OrderDto;
using ECommerceWebsite.Models;
using ECommerceWebsite.Services.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceWebsite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        //[Authorize]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrderAsync()
        {
            var order = await _orderService.GetOrderAsync();
            return Ok(order);
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<Order>> GetByIdAsync(int id)
        {
            var order = await _orderService.GetByIdAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            return Ok(order);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Order>> PostOrder(CreateOrderDto orderDto)
        {
            var data = await _orderService.CreateAsync(orderDto);

            if (data == null)
            {
                return NoContent();
            }
            return CreatedAtAction("GetOrder", new { id = data.OrderId }, orderDto);
        }

        /*[HttpPut]
        [Route("{id}")]
        public async Task<ActionResult<Order?>> UpdateAsync(int id, UpdateOrderDto orderDto)
        {
            var order = await _orderService.UpdateAsync(id, orderDto);
            if (order == null)
            {
                return NotFound();
            }

            return Ok(order);
        }*/

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var order = await _orderService.DeleteAsync(id);
            if (order == false)
            {
                return NotFound();
            }
            return NoContent();

        }

    }
}
