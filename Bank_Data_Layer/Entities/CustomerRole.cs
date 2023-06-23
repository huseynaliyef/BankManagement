using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Data_Layer.Entities
{
    public class CustomerRole
    {
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }


        public int RoleId { get; set; } 
        public Role Role { get; set; }
    }
}
