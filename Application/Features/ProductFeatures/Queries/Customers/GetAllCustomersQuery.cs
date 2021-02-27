using Application.Interfaces;
using DomainModel.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.ProductFeatures.Queries.Customers
{
    public class GetAllCustomersQuery : IRequest<IEnumerable<Customer>>
    {
        public class GetAllCustomersQueryHAndler : IRequestHandler<GetAllCustomersQuery, IEnumerable<Customer>>
        {
            private readonly IApplicationContext _context;

            public GetAllCustomersQueryHAndler(IApplicationContext context)
            {
                _context = context;
            }

            public async Task<IEnumerable<Customer>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
            {
                var customersList = await _context.Customers.ToListAsync();
                return customersList.AsReadOnly();
            }
        }
    }
}
