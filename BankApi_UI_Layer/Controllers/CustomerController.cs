using Bank_Logic_Layer.Logics;
using Bank_Logic_Layer.Models.DTO.Customer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BankApi_UI_Layer.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerLogic _customerLogic;
        public CustomerController(CustomerLogic customerLogic)
        {
            _customerLogic = customerLogic;
        }
        [HttpPost]
        public async Task<IActionResult> Register(CustomerRegisterUIDTO customer)
        {
            var registerOperation = await _customerLogic.customerRegistration(customer);
            if (registerOperation)
            {
                return Ok("Successfully Registration.");
            }
            return BadRequest("Username is exist!");
        }

        [HttpPost]
        public async Task<IActionResult> Login(CustomerLoginUIDTO customer)
        {
            var loginOperation = await _customerLogic.customerLogin(customer);
            if (loginOperation)
            {
                HttpContext.Response.Cookies.Append("user", Guid.NewGuid().ToString());
                return Ok("You successfully logined.");
            }
            return BadRequest("Username or password is wrong!");
        }

        [HttpPut]
        public async Task<IActionResult> GiveRole(RoleUIDTO role)
        {
            var operation = await _customerLogic.GiveRoleToCustomer(role);
            if (operation)
            {
                return Ok("Role succuessfully given.");
            }
            return BadRequest("Occure Error");
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            HttpContext.Response.Cookies.Delete("user");
            return Ok("Successfully Logout.");
        }
    }
}
