using Application.Interfaces;
using DomainModel.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.ProductFeatures.Queries.Customers
{
    public class GetCustomerByIdQuery: IRequest<Customer>
    {
        public int Id { get; set;}

        public class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, Customer>
        {
            IApplicationContext _context;

            public GetCustomerByIdQueryHandler(IApplicationContext context)
            {
                _context = context;
            }
            public async Task<Customer> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
            {
                var Customer = await _context.Customers.FindAsync(request.Id);
                return Customer;
            }
        }
    }
}
