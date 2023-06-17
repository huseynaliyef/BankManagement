using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Data_Layer.Entities
{
    public class Bank: BaseEntity
    {
        public string Name { get; set; }
        public ICollection<CardType> CardTypes { get; set; }
    }
}
