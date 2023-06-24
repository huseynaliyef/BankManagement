using Bank_Data_Layer.Entities;
using Bank_Logic_Layer.Abstractions;
using Bank_Logic_Layer.Models.DTO.CardUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Logic_Layer.Logics
{
    public class CardUserLogic
    {
        private readonly IGenericRepository<CardType> _cardTypeRepository;
        private readonly IGenericRepository<CardUser> _cardUserRepository;
        public CardUserLogic(IGenericRepository<CardType> cardTypeRepository,
                IGenericRepository<CardUser> cardUserRepository)
        {
            _cardTypeRepository = cardTypeRepository;
            _cardUserRepository = cardUserRepository;
        }
        public async Task<bool> CreateCardUser(CardUserCreateUIDTO cardUser)
        {
            bool check = true;
            long newnumber = 0;
            var cardType = await _cardTypeRepository.Find(cardUser.CardTypeId);
            Random r = new Random();
            while (check)
            {
                newnumber = Convert.ToInt64(cardType.CardNumber8.ToString() + r.Next(10000000, 99999999).ToString());
                var existUserCard = await _cardUserRepository.GetTableByExpession(x => x.UserNumber8 == newnumber);
                if (existUserCard.Count == 0) check = false;
            }
            

            CardUser newCardUser = new CardUser();
            newCardUser.CreateDate = DateTime.Now;
            newCardUser.CardTypeId = cardUser.CardTypeId;
            newCardUser.CustomerId = cardUser.CustomerId;
            newCardUser.UserNumber8 = newnumber;
            newCardUser.Cvv = r.Next(100, 999);
            newCardUser.PinCode = cardUser.PinCode;
            newCardUser.ExpireDate = DateTime.Now.AddYears(cardType.ExpireYear);
            await _cardUserRepository.AddAndCommit(newCardUser);
            return true;
        }

        public async Task<bool> UpdatePinCode(CardUserUpdatePinCodeUIDTO cardUser)
        {
            var existCardUser = await _cardUserRepository.Find(cardUser.CardUserId);
            if(existCardUser == null)
            {
                return false;
            }
            else
            {
                existCardUser.PinCode = cardUser.newPinCode;
                _cardUserRepository.Update(existCardUser);
                await _cardUserRepository.Commit();
                return true;
            }
        }
    }
}
