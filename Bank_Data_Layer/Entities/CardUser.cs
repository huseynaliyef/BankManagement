using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Data_Layer.Entities
{
    public class CardUser:BaseEntity
    {
        public int CardTypeId { get; set; }
        public CardType CardType { get; set; }
        public Customer Customer { get; set; }
        public int CustomerId { get; set; }
        public long UserNumber8 { get; set; }
        public int Cvv { get; set; }
        public string PinCode { get; set; }
        public DateTime ExpireDate {  get; set; }

    }
}
