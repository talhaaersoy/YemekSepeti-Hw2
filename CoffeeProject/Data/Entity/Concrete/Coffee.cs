using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffeeProject.Data.Entity.Abstract;

namespace CoffeeProject.Data.Entity.Concrete
{
    public class Coffee:IBeverage
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }
        public string CreatedBy { get; set; }

    }
}
