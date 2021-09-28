using SimpleSite.Entities.Contracts;
using SimpleSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace SimpleSite.Services
{
    public class OrderProductService : IOrderProductService
    {
        private DataManager _dataManager { get; set; }
        public OrderProductService(DataManager dataManager)
        {
            _dataManager = dataManager;
        }

        public async Task<List<OrderProduct>> GetAllAsync()
        {
            return await _dataManager._orderProductRepository.GetAllAsync();
        }

        public async Task<OrderProduct> AddAsync(OrderProduct entity)
        {
            return await _dataManager._orderProductRepository.AddAsync(entity);
        }

        public void Delete(Guid id)
        {
            _dataManager._orderProductRepository.Delete(id);
        }
    }
}