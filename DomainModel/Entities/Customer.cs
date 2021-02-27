using DomainModel.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.Entities
{
    public class Customer : BaseEntity
    {
        public string CustomerName { get; set; }
        public string CustomerSurname { get; set; }
        public List<Order> Orders { get; set; }
    }
}
