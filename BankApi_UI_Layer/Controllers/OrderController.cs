using Bank_Logic_Layer.Logics;
using Bank_Logic_Layer.Models.DTO.Order;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BankApi_UI_Layer.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly OrderLogic _orderLogic;

        public OrderController(OrderLogic orderLogic)
        {
            _orderLogic = orderLogic;
        }

        [HttpPost]
        public async Task<IActionResult> OrderCard(CreateOrderUIDTO orderDTO)
        {
            var isCreated = await _orderLogic.CreateOrder(orderDTO);
            if (isCreated)
            {
                return Ok("Order Accepted!");
            }
            return BadRequest("Order has not been accepted!");
        }

        [HttpGet]
        public async Task<IActionResult> GetOrders()
        {
            var orders = await _orderLogic.GetOrders();
            if (orders.Count != 0)
            {
                return Ok(orders);
            }
            return BadRequest("There are no orders!");
        }

        [HttpPatch]
        public async Task<IActionResult> UpdateOrder(UpdateOrderUIDTO orderDTO)
        {
            var isUpdated = await _orderLogic.UpdateOrder(orderDTO);
            if (isUpdated)
            {
                return Ok("Order updated successfully!");
            }
            return BadRequest("Failed to update an order!");
        }


        [HttpDelete]
        public async Task<IActionResult> DeleteOrder(DeleteOrderUIDTO orderDTO)
        {
            var isDeleted = await _orderLogic.DeleteOrder(orderDTO);
            if (isDeleted)
            {
                return Ok("Order deleted successfully!");
            }
            return BadRequest("Failed to delete an order!");
        }
    }
}
