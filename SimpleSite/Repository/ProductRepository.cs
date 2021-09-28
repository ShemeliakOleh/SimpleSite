using Newtonsoft.Json;
using SimpleSite.Entities.Contracts;
using SimpleSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using AppContext = SimpleSite.Models.AppContext;

namespace SimpleSite.Entities.Repository
{
    public class ProductRepository : IProductRepository
    {
        private AppContext _dbContext { get; set; }

        public ProductRepository(AppContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Product> AddAsync(Product entity)
        {
            var product = _dbContext.Product.SingleOrDefault(x => x.Id == entity.Id);

            if (product != null) throw new Exception($"Product with Id {entity.Id} already exists");

            product = _dbContext.Product.Add(entity);

             _dbContext.SaveChanges();
           
            return product;
        }

        public void Delete(Guid Id)
        {
            var product = _dbContext.Product.SingleOrDefault(x => x.Id == Id);

            if(product == null)
            {
                throw new Exception($"Product with id {Id} not found");
            }

            if (product.OrderProduct.Count != 0)
            {
                throw new Exception($"Failed to delete because OrderProducts with ids :{JsonConvert.SerializeObject(product.OrderProduct.Select(x => x.Id))} depend on the product");
            }

            _dbContext.Product.Remove(product);
                _dbContext.SaveChanges();
            
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return _dbContext.Product.ToList();
        }
    }
}