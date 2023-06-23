using Bank_Logic_Layer.Logics;
using Bank_Logic_Layer.Models.DTO.CardType;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BankApi_UI_Layer.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CardTypeController : ControllerBase
    {
        private readonly CardTypeLogic _cardTypeLogic;

        public CardTypeController(CardTypeLogic cardTypeLogic)
        {
            _cardTypeLogic = cardTypeLogic;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCardType(CreateCardTypeUIDTO cardTypeDTO)
        {
            var isAdded = await _cardTypeLogic.CreateCardType(cardTypeDTO);

            if (isAdded)
            {
                return Ok("Successfully created.");
            }
            return BadRequest("Failed to create card type.");
        }

        [HttpGet]
        public async Task<IActionResult> GetCardType()
        {
            var cardTypes = await _cardTypeLogic.GetCardType();

            if (cardTypes.Count != 0)
            {
                return Ok(cardTypes);
            }
            return BadRequest("Card types does not exists.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCardType(UpdateCardTypeUIDTO cardTypeDTO)
        {
            var isUpdated = await _cardTypeLogic.UpdateCardType(cardTypeDTO);
            if (isUpdated)
            {
                return Ok("Updated Successfully.");
            }
            return BadRequest("Failed to update.");
        }

        [HttpPut]
        public async Task<IActionResult> DeactivateCardType(DeactivateCardTypeUIDTO cardTypeDTO)
        {
            var isDeactivated = await _cardTypeLogic.DeactivateCardType(cardTypeDTO);
            if (isDeactivated)
            {
                return Ok("Card type deactivated.");
            }
            return BadRequest("Failed to deactivate.");
        }
    }
}
