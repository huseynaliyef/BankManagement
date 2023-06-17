using Bank_Data_Layer.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

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
        public async Task<IActionResult> GetOrdersAsync()
        {
            int a = 5;
            var Orders = await _context.Orders.ToListAsync();
            return Ok(Orders);
        }
    }
}
