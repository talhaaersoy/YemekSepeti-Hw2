using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffeeProject.Data.Entity;
using CoffeeProject.Data.Entity.Abstract;
using CoffeeProject.Data.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace CoffeeProject.Data.Context
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {
        
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Coffee> Coffees { get; set; }



    }


}
