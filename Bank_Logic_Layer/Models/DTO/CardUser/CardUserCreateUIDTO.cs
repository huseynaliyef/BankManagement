using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Logic_Layer.Models.DTO.CardUser
{
    public class CardUserCreateUIDTO
    {
        public int CardTypeId { get; set; }
        public int CustomerId { get; set; }
        public string PinCode { get; set; }

    }
}
