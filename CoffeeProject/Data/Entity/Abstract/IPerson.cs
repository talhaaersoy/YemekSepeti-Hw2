using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeProject.Data.Entity.Abstract
{
    public interface IPerson
    {
        public string Id { get; set; }
        public string UserName { get; set; }
    }
}
