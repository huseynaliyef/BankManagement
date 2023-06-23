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
        private readonly IGenericRepository<Role> _roleRepository;
        private readonly IGenericRepository<CustomerRole> _customerRoleRepository;
        public CustomerLogic(IGenericRepository<Customer> customerRepository,
                            IGenericRepository<Role> roleRepository,
                            IGenericRepository<CustomerRole> customerRoleRepository)
        {
            _customerRepository = customerRepository;
            _roleRepository = roleRepository;
            _customerRoleRepository = customerRoleRepository;
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

        public async Task<bool> GiveRoleToCustomer(RoleUIDTO role)
        {
            var giveRole = await _roleRepository.Find(role.Id);
            var customer = await _customerRepository.Find(role.CustomerId);
            if (giveRole != null && customer != null)
            {
                await _customerRoleRepository
                    .AddAndCommit(new CustomerRole { CustomerId = customer.Id, RoleId = role.Id });
                
                return true;
            }
            return false;
        }

    }
}
