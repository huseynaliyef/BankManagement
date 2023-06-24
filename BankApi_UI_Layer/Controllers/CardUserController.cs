using Bank_Logic_Layer.Logics;
using Bank_Logic_Layer.Models.DTO.CardUser;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BankApi_UI_Layer.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CardUserController : ControllerBase
    {
        private readonly CardUserLogic _carUserLogic;
        public CardUserController(CardUserLogic carUserLogic)
        {
            _carUserLogic = carUserLogic;
        }
        [HttpPost]
        public async Task<IActionResult> CardUserCreate(CardUserCreateUIDTO cardUser)
        {
            var createOperation = await _carUserLogic.CreateCardUser(cardUser);
            if (createOperation)
            {
                return Ok("Card created successfully for User");
            }
            return BadRequest("Occured error creating");
        }

        [HttpPatch]
        public async Task<IActionResult> UpdatePinCode(CardUserUpdatePinCodeUIDTO carduser)
        {
            var updateOperation = await _carUserLogic.UpdatePinCode(carduser);
            if (updateOperation)
            {
                return Ok("update is Successfully");
            }
            return BadRequest("Occured error updating");
        }
    }
}
