using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffeeProject.Data.Entity.Concrete;
using Microsoft.EntityFrameworkCore;

namespace CoffeeProject.Data.Context
{
    public class InMemoryCoffees
    {
        private DbContextOptions<DataBaseContext> options;

        private InMemoryCoffees()
        {
            options = new DbContextOptionsBuilder<DataBaseContext>()
                .UseInMemoryDatabase("CustomerDb")
                .Options;
            using (var context = new DataBaseContext(options))
            {
                context.Coffees.AddRange(coffees);
                context.SaveChanges();
            }
        }

        public static InMemoryCoffees Instance { get { return Nested.instance; } }

        private class Nested
        {
            static Nested()
            {
            }

            internal static readonly InMemoryCoffees instance = new InMemoryCoffees();
        }

        List<Coffee> coffees = new List<Coffee>
        {
            new Coffee{Id = 1,Name = "cappuccino",UnitPrice = 15,CreatedBy = "director"},
            new Coffee{Id = 2,Name = "latte",UnitPrice = 12,CreatedBy = "director"},
            new Coffee{Id = 3,Name = "americano",UnitPrice = 10,CreatedBy = "director"}
        };

    }
}
