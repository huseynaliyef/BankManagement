using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Logic_Layer.Models.DTO.CardType
{
    public class UpdateCardTypeUIDTO
    {
        public int Id { get; set; }
        public double CashBack { get; set; }
        public long CardNumber8 { get; set; }
        public int ExpireYear { get; set; }
    }
}
