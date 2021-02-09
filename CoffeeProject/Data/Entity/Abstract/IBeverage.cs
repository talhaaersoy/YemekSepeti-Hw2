using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeProject.Data.Entity.Abstract
{
    public interface IBeverage
    {
       
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
