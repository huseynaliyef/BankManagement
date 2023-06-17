using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Data_Layer.Entities
{
    public class Order:BaseEntity
    {
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int CardTypeId{ get; set; }
        public CardType CardType { get; set; }
        public string Status { get; set; }
    }
}
