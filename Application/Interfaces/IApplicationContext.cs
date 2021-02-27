using DomainModel.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IApplicationContext
    {
        DbSet<Order> Orders { get; set; }
        DbSet<Customer> Customers { get; set; }
        Task<int> SaveChangesAsync();
    }
}
