using AutoMapper;
using SimpleSite.Entities;
using SimpleSite.Entities.Contracts;
using SimpleSite.Models;
using SimpleSite.Models.DTOs;
using SimpleSite.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;

namespace SimpleSite.Controllers
{
    public class ProductController : ApiController
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IHttpActionResult> Get()
        {
            try
            {
                var result = await _productService.GetAllAsync();

                return Ok(new SimpleHttpResultModel<IEnumerable<ProductDto>>(true, HttpStatusCode.OK)
                {
                    Content = result.Select(x=>_mapper.Map<Product,ProductDto>(x))
                });
            }
            catch (Exception ex)
            {
                return Ok(ApiErrorHandler.HandleExceptionAsResult(ex));
            }
            
        }

        [HttpPost]
        public async Task<IHttpActionResult> Post([FromBody] ProductDto productDto)
        {
            if (productDto == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var product = _mapper.Map<ProductDto, Product>(productDto);

                var result = new SimpleHttpResultModel<ProductDto>(true, HttpStatusCode.OK);

                result.Content = _mapper.Map<Product, ProductDto>(await _productService.AddAsync(product));

                return Ok(result);
            }
            catch (Exception ex)
            {
                return Ok(ApiErrorHandler.HandleExceptionAsResult(ex));
            }
        }

        [HttpDelete]
        public IHttpActionResult Delete(Guid id)
        {
            try
            {
                _productService.Delete(id);
                return Ok(new SimpleHttpResultModel<string>(true, HttpStatusCode.OK)
                {
                    Message = $"Product with Id {id} was successfully deleted"
                });
            }
            catch (Exception ex)
            {
                return Ok(ApiErrorHandler.HandleExceptionAsResult(ex));
            }
        }
    }
}
