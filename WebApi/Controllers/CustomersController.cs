using System.Threading.Tasks;
using Application.Features.ProductFeatures.Queries.Customers;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        [HttpGet]
        public async Task<IActionResult> GetAllCustomers()
        {
            return Ok(await Mediator.Send(new GetAllCustomersQuery()));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetCustomerById(int id)
        {
            return Ok(await Mediator.Send(new GetCustomerByIdQuery { Id = id }));
        }

        [HttpGet("{name}-{surname}")]
        public async Task<IActionResult> GetCustomersByNameAndSurname(string name, string surname)
        {
            return Ok(await Mediator.Send(new GetCustomersByNameAndSurnameQuery { Name = name, Surname = surname }));
        }
    }
}
