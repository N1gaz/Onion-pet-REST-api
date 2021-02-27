using DomainModel.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.Entities
{
    public class Customer : BaseEntity
    {
        public string CustomrName { get; set; }
        public string CutomerSurname { get; set; }
        public List<Order> Orders { get; set; }
    }
}
