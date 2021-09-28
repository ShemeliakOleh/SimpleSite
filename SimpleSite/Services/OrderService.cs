using SimpleSite.Entities.Contracts;
using SimpleSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace SimpleSite.Services
{
    public class OrderService : IOrderService
    {
        private DataManager _dataManager { get; set; }
        public OrderService(DataManager dataManager)
        {
            _dataManager = dataManager;
        }

        public async Task<List<Order>> GetAllAsync()
        {
            return await _dataManager._orderRepository.GetAllAsync();
        }

        public async Task<Order> AddAsync(Order entity)
        {
            return await _dataManager._orderRepository.AddAsync(entity);
        }

        public void Delete(Guid id)
        {
            _dataManager._orderRepository.Delete(id);
        }
    }
}