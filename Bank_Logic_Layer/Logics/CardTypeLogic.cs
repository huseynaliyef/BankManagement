using Bank_Data_Layer.Entities;
using Bank_Logic_Layer.Abstractions;
using Bank_Logic_Layer.Models.DTO.CardType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Logic_Layer.Logics
{
    public class CardTypeLogic
    {
        private readonly IGenericRepository<CardType> _cardTypeRepository;
        public CardTypeLogic(IGenericRepository<CardType> cardTypeRepository)
        {
            _cardTypeRepository = cardTypeRepository;
        }

        public async Task<bool> CreateCardType(CreateCardTypeUIDTO cardTypeDTO)
        {
            var cardType = new CardType()
            {
                BankId = cardTypeDTO.BankId,
                CashBack = cardTypeDTO.CashBack,
                CardNumber8 = cardTypeDTO.CardNumber8,
                ExpireYear = cardTypeDTO.ExpireYear,
                IsActive = cardTypeDTO.IsActive,
                CreateDate = DateTime.Now
            };

            await _cardTypeRepository.AddAndCommit(cardType);
            return true;
        }

        public async Task<List<GetCardTypeUIDTO>> GetCardType()
        {
            var cardTypes = await _cardTypeRepository.GetAll();
            List<GetCardTypeUIDTO> cardTypeDTOS = new List<GetCardTypeUIDTO>(); 

            foreach (var cardType in cardTypes)
            {
                cardTypeDTOS.Add(new GetCardTypeUIDTO()
                {
                    BankId = cardType.BankId,   
                    CashBack = cardType.CashBack,
                    ExpireYear = cardType.ExpireYear
                });
            }
            return cardTypeDTOS;
        }

        public async Task<bool> UpdateCardType(UpdateCardTypeUIDTO cardTypeDTO)
        {
            var cardType = await _cardTypeRepository.Find(cardTypeDTO.Id);

            if (cardType is not null)
            {
                cardType.CashBack = cardTypeDTO.CashBack;
                cardType.ExpireYear = cardTypeDTO.ExpireYear;    
                cardType.CardNumber8 = cardTypeDTO.CardNumber8;

                _cardTypeRepository.Update(cardType);
                await _cardTypeRepository.Commit();
                return true;
            }
            return false;
        }

        public async Task<bool> DeactivateCardType(DeactivateCardTypeUIDTO cardTypeDTO)
        {
            var cardType = await _cardTypeRepository.Find(cardTypeDTO.Id);

            if (cardType is not null)
            {
                cardType.IsActive = false;  
                _cardTypeRepository.Update(cardType);
                await _cardTypeRepository.Commit();
                return true;
            }
            return false;
        }
    }
}
