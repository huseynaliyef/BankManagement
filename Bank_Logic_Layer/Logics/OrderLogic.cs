using Bank_Data_Layer.Entities;
using Bank_Logic_Layer.Abstractions;
using Bank_Logic_Layer.Models.DTO.CardType;
using Bank_Logic_Layer.Models.DTO.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Logic_Layer.Logics
{
    public class OrderLogic
    {
        private readonly IGenericRepository<Order> _orderRepository;

        public OrderLogic(IGenericRepository<Order> orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<bool> CreateOrder(CreateOrderUIDTO orderDTO)
        {
            var order = new Order()
            {
                CustomerId = orderDTO.CustomerId,
                CardTypeId = orderDTO.CardTypeId,   
                Status = "Order on hold!",
                CreateDate = DateTime.Now
            };

            await _orderRepository.AddAndCommit(order);
            return true;    
        }

        public async Task<List<GetOrdersUIDTO>> GetOrders()
        {
            var orders = await _orderRepository.GetAll();
            List<GetOrdersUIDTO> orderDTOs = new List<GetOrdersUIDTO>();

            foreach (var order in orders)
            {
                orderDTOs.Add(new GetOrdersUIDTO
                {
                    CustomerId = order.CustomerId,
                    CardTypeId = order.CardTypeId,
                    Status = order.Status,
                    CreateDate = order.CreateDate
                });
            }

            return orderDTOs;
        }

        public async Task<bool> UpdateOrder(UpdateOrderUIDTO orderDTO)
        {
            var order = await _orderRepository.Find(orderDTO.Id);

            if (order == null)
            {
                return false;
            }
            else
            {
                order.Status = orderDTO.Status;

                _orderRepository.Update(order);
                await _orderRepository.Commit();
                return true;
            }        
        }

        public async Task<bool> DeleteOrder(DeleteOrderUIDTO orderDTO)
        {
            var order = await _orderRepository.Find(orderDTO.Id);

            if (order == null)
            {
                return false;
            }
            else
            {
                _orderRepository.Delete(order.Id);
                await _orderRepository.Commit();
                return true;
            }
        }
    }
}
