using Application.Interfaces;
using DomainModel.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.ProductFeatures.Queries
{
    public class GetOrdersByDateQuery : IRequest<IEnumerable<Order>>
    {
        public DateTime Date { get; set; }

        public class GetOrdersByDateQueryHandler : IRequestHandler<GetOrdersByDateQuery, IEnumerable<Order>>
        {
            private readonly IApplicationContext _context;

            public GetOrdersByDateQueryHandler(IApplicationContext context)
            {
                _context = context;
            }

            public async Task<IEnumerable<Order>> Handle(GetOrdersByDateQuery request, CancellationToken cancellationToken)
            {
                var ordersList = await _context.Orders.Where(a => a.OrderDate.Equals(request.Date)).ToListAsync();
                if (ordersList == null)
                {
                    return null;
                }

                return ordersList.AsReadOnly();
            }
        }

    }
}
