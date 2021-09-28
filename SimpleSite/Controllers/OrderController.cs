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
    public class OrderController : ApiController
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;
        public OrderController(IOrderService orderService, IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IHttpActionResult> Get()
        {
            try
            {
                var result = await _orderService.GetAllAsync();

                return Ok(new SimpleHttpResultModel<IEnumerable<OrderDto>>(true, HttpStatusCode.OK)
                {
                    Content = result.Select(x => _mapper.Map<Order, OrderDto>(x))
                });
            }
            catch (Exception ex)
            {
                return Ok(ApiErrorHandler.HandleExceptionAsResult(ex));
            }

        }

        [HttpPost]
        public async Task<IHttpActionResult> Post([FromBody] OrderDto orderDto)
        {
            if (orderDto == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var order = _mapper.Map<OrderDto, Order>(orderDto);

                var result = new SimpleHttpResultModel<OrderDto>(true, HttpStatusCode.OK);

                result.Content = _mapper.Map<Order, OrderDto>(await _orderService.AddAsync(order));

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
                _orderService.Delete(id);
                return Ok(new SimpleHttpResultModel<string>(true, HttpStatusCode.OK)
                {
                    Message = $"Order with Id {id} was successfully deleted"
                });
            }
            catch (Exception ex)
            {
                return Ok(ApiErrorHandler.HandleExceptionAsResult(ex));
            }
        }
    }
}
