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
    public class OrderProductRepository : IOrderProductRepository
    {
        private AppContext _dbContext { get; set; }

        public OrderProductRepository(AppContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<OrderProduct> AddAsync(OrderProduct entity)
        {
            var orderProduct = _dbContext.OrderProduct.SingleOrDefault(x => x.Id == entity.Id);

            if (orderProduct != null) throw new Exception($"OrderProduct with Id {entity.Id} already exists");

            var product = _dbContext.Product.SingleOrDefault(x => x.Id == entity.ProductId);

            if(product == null) throw new Exception($"Product with Id {entity.ProductId} doesn't exist");
            
            var order = _dbContext.Order.SingleOrDefault(x => x.Id == entity.OrderId);

            if (order == null) throw new Exception($"Order with Id {entity.OrderId} doesn't exist");

            entity.Product = product;
            entity.Order = order;

            orderProduct = _dbContext.OrderProduct.Add(entity);

            _dbContext.SaveChanges();

            return orderProduct;
        }

        public void Delete(Guid Id)
        {
            var orderProduct = _dbContext.OrderProduct.SingleOrDefault(x => x.Id == Id);

            if (orderProduct == null)
            {
                throw new Exception($"OrderProduct with id {Id} not found");
            }
            else
            {
                _dbContext.OrderProduct.Remove(orderProduct);
                _dbContext.SaveChanges();
            }
        }

        public async Task<List<OrderProduct>> GetAllAsync()
        {
            return _dbContext.OrderProduct.ToList();
        }
    }
}