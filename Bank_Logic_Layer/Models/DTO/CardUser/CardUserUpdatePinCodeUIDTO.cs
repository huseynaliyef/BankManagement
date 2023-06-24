using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Logic_Layer.Models.DTO.CardUser
{
    public class CardUserUpdatePinCodeUIDTO
    {
        public int CardUserId { get; set; }
        public string newPinCode { get; set; }
    }
}
