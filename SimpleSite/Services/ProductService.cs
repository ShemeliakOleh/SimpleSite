using SimpleSite.Entities.Contracts;
using SimpleSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace SimpleSite.Services
{
    public class ProductService:IProductService
    {
        private DataManager _dataManager { get; set; }
        public ProductService(DataManager dataManager)
        {
            _dataManager = dataManager;
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await _dataManager._productRepository.GetAllAsync();
        }

        public async Task<Product> AddAsync(Product entity)
        {
            return await _dataManager._productRepository.AddAsync(entity);
        }

        public void Delete(Guid id)
        {
            _dataManager._productRepository.Delete(id);
        }
    }
}