using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Logic_Layer.Models.DTO.Order
{
    public class GetOrdersUIDTO
    {
        public int CustomerId { get; set; }
        public int CardTypeId { get; set; }
        public string Status { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
