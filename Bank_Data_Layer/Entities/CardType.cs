using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Data_Layer.Entities
{
    public class CardType:BaseEntity
    {
        public int BankId { get; set; }
        public double CashBack { get; set; }
        public long CardNumber8 { get; set; }
        public int ExpireYear { get; set; }
        public bool IsActive { get; set; }
        public ICollection<Order> Orders { get; set; }
        public Bank Bank { get; set; }
    }
}
