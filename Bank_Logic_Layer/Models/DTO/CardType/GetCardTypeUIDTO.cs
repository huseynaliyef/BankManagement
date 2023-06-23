using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Logic_Layer.Models.DTO.CardType
{
    public class GetCardTypeUIDTO
    {
        public int BankId { get; set; }
        public double CashBack { get; set; }
        public int ExpireYear { get; set; }
    }
}
