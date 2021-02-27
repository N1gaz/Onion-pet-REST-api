﻿using Application.Interfaces;
using DomainModel.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.ProductFeatures.Queries
{
    public class GetAllOrdersQuery : IRequest<IEnumerable<Order>>
    {
        public class GetAllOrdersQueryHandler : IRequestHandler<GetAllOrdersQuery, IEnumerable<Order>>
        {
            private readonly IApplicationContext _context;

            public GetAllOrdersQueryHandler(IApplicationContext context)
            {
                _context = context;
            }

            public async Task<IEnumerable<Order>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
            {
                var ordersList = await _context.Orders.ToListAsync();
                if (ordersList == null)
                {
                    return null;
                }
                return ordersList.AsReadOnly();
            }
        }
    }
}
