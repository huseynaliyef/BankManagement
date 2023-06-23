using Bank_Data_Layer.Entities;
using Bank_Logic_Layer.Abstractions;
using Bank_Logic_Layer.Models.DTO.Customer;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Logic_Layer.Logics
{
    public class CustomerLogic
    {
        private readonly IGenericRepository<Customer> _customerRepository;
        public CustomerLogic(IGenericRepository<Customer> customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<bool> customerRegistration(CustomerRegisterUIDTO customer)
        {
            var existCustomer = await _customerRepository.GetTableByExpession(x => x.UserName == customer.UserName);
            if(existCustomer.Count == 0)
            {
                Customer newCustomer = new Customer();
                newCustomer.CreateDate = DateTime.Now;
                newCustomer.UserName = customer.UserName;
                newCustomer.FinCode = customer.FinCode;
                newCustomer.Password = customer.Password;
                await _customerRepository.AddAndCommit(newCustomer);
                return true;
            }
            return false;
            
        }

        public async Task<bool> customerLogin(CustomerLoginUIDTO customer)
        {
            var existCustomer = await _customerRepository.GetTableByExpession(x => x.UserName == customer.UserName && x.Password == customer.Password);
            if(existCustomer.Count != 0) 
            {
                return true;
            }
            return false; 
        }

        
    }
}
