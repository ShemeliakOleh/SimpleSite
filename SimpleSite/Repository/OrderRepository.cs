using Newtonsoft.Json;
using SimpleSite.Entities.Contracts;
using SimpleSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using AppContext = SimpleSite.Models.AppContext;

namespace SimpleSite.Entities.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private AppContext _dbContext { get; set; }

        public OrderRepository(AppContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Order> AddAsync(Order entity)
        {
            var order = _dbContext.Order.SingleOrDefault(x => x.Id == entity.Id);

            if (order != null) throw new Exception($"Order with Id {entity.Id} already exists");

            order = _dbContext.Order.Add(entity);

            _dbContext.SaveChanges();

            return order;
        }

        public void Delete(Guid Id)
        {
            var order = _dbContext.Order.SingleOrDefault(x => x.Id == Id);

            if (order == null)
            {
                throw new Exception($"Order with id {Id} not found");
            }

            if (order.OrderProduct.Count != 0)
            {
                throw new Exception($"Failed to delete order because OrderProducts with ids :{JsonConvert.SerializeObject(order.OrderProduct.Select(x => x.Id))} depend on the order");
            }

            _dbContext.Order.Remove(order);
            _dbContext.SaveChanges();

        }

        public async Task<List<Order>> GetAllAsync()
        {
            return _dbContext.Order.ToList();
        }
    }
}