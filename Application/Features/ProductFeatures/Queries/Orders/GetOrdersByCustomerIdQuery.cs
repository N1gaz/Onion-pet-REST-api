using Application.Interfaces;
using DomainModel.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.ProductFeatures.Queries.Orders
{
    public class GetOrdersByCustomerIdQuery : IRequest<IEnumerable<Order>>
    {
        public int Id { get; set; }

        public class GetOrdersByCustomerIdQueryHandler : IRequestHandler<GetOrdersByCustomerIdQuery, IEnumerable<Order>>
        {
            private readonly IApplicationContext _context;

            public GetOrdersByCustomerIdQueryHandler(IApplicationContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<Order>> Handle(GetOrdersByCustomerIdQuery request, CancellationToken cancellationToken)
            {
                var ordersList = await _context.Orders.Where(a => a.CustomerId == request.Id).ToListAsync();
                if (ordersList == null)
                {
                    return null;
                }
                return ordersList.AsReadOnly();
            }
        }
    }
}
