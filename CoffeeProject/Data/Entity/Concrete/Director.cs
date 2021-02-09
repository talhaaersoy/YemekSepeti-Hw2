using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffeeProject.Data.Entity.Abstract;

namespace CoffeeProject.Data.Entity.Concrete
{
    public class Director:IPerson
    {
        public string Id { get; set; }
        public string UserName { get; set; }
    }
}
