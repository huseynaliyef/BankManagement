using Bank_Data_Layer.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BankApi_UI_Layer.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly BankDbContext _context;
        public OrderController(BankDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetOrders()
        {
            var Orders = _context.Orders.ToList();
            return Ok(Orders);
        }
    }
}
