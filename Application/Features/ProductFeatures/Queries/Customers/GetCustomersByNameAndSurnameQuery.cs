using Application.Interfaces;
using DomainModel.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.ProductFeatures.Queries.Customers
{
    public class GetCustomersByNameAndSurnameQuery : IRequest<IEnumerable<Customer>>
    {
        public string Name { get; set; }
        public string Surname { get; set; }

        public class GetCustomersByNameAndSurnameQueryHandler : IRequestHandler<GetCustomersByNameAndSurnameQuery, IEnumerable<Customer>>
        {
            IApplicationContext _context;

            public GetCustomersByNameAndSurnameQueryHandler(IApplicationContext context)
            {
                _context = context;
            }

            public async Task<IEnumerable<Customer>> Handle(GetCustomersByNameAndSurnameQuery request, CancellationToken cancellationToken)
            {
                var CustomersList = await _context
                    .Customers
                    .Where(a => a.CustomerName == request.Name && a.CustomerSurname == request.Surname)
                    .ToListAsync();

                return CustomersList.AsReadOnly();
            }
        }
    }
}
