using Application.Features.ProductFeatures.Queries.Orders;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        [HttpGet]
        public async Task<IActionResult> GetAllOrders()
        {
            return Ok(await Mediator.Send(new GetAllOrdersQuery()));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetOrdersByCustomerId(int id)
        {
            return Ok(await Mediator.Send(new GetOrdersByCustomerIdQuery {Id = id}));
        }

        [HttpGet("{date}")]
        public async Task<IActionResult> GetOrdersByDate(DateTime date)
        {
            
            return Ok(await Mediator.Send(new GetOrdersByDateQuery { Date = date }));
        }

    }
}
