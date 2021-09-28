using SimpleSite.Contracts.IService;
using SimpleSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace SimpleSite.Entities.Contracts
{
    public interface IProductService:IService<Product>
    {
       
    }
}