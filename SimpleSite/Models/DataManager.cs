using SimpleSite.Entities.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleSite.Models
{
    public class DataManager
    {
        public IProductRepository _productRepository { get; set; }
        public IOrderRepository _orderRepository { get; set; }
        public IOrderProductRepository _orderProductRepository { get; set; }

        public DataManager(IProductRepository productRepository, IOrderRepository orderRepository, IOrderProductRepository orderProductRepository)
        {
            _productRepository = productRepository;
            _orderRepository = orderRepository;
            _orderProductRepository = orderProductRepository;
        }
    }
}