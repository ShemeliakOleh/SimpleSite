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
using System.Web.Http;

namespace SimpleSite.Controllers
{
    public class OrderProductController : ApiController
    {
        private IOrderProductService _orderProductService;
        private readonly IMapper _mapper;
        public OrderProductController(IOrderProductService orderProductService, IMapper mapper)
        {
            _orderProductService = orderProductService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IHttpActionResult> Get()
        {
            try
            {
                var result = await _orderProductService.GetAllAsync();

                return Ok(new SimpleHttpResultModel<IEnumerable<OrderProductDto>>(true, HttpStatusCode.OK)
                {
                    Content = result.Select(x => _mapper.Map<OrderProduct, OrderProductDto>(x))
                });
            }
            catch (Exception ex)
            {
                return Ok(ApiErrorHandler.HandleExceptionAsResult(ex));
            }

        }

        [HttpPost]
        public async Task<IHttpActionResult> Post([FromBody] OrderProductDto orderProductDto)
        {
            if (orderProductDto == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var orderProduct = _mapper.Map<OrderProductDto, OrderProduct>(orderProductDto);

                var result = new SimpleHttpResultModel<OrderProductDto>(true, HttpStatusCode.OK);

                result.Content = _mapper.Map<OrderProduct, OrderProductDto>(await _orderProductService.AddAsync(orderProduct));

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
                _orderProductService.Delete(id);
                return Ok(new SimpleHttpResultModel<string>(true, HttpStatusCode.OK)
                {
                    Message = $"OrderProduct with Id {id} was successfully deleted"
                });
            }
            catch (Exception ex)
            {
                return Ok(ApiErrorHandler.HandleExceptionAsResult(ex));
            }
        }
    }
}
