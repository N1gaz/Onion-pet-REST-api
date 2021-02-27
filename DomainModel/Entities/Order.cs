using DomainModel.Common;
using System;

namespace DomainModel.Entities
{
    public class Order : BaseEntity
    {
        public int CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal OrderPrice { get; set; }
        public Customer Customer { get; set; }
    }
}
