using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Data_Layer.Entities
{
    public class Customer:BaseEntity
    {
        public string FinCode { get; set; }
        public  string UserName { get; set; }
        public string Password { get; set; }
        public List<Order> Orders { get; set; }
    }
}
