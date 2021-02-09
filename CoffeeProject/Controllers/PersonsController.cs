using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using CoffeeProject.Data.Context;
using CoffeeProject.Data.Entity;
using CoffeeProject.Data.Entity.Abstract;
using CoffeeProject.Data.Entity.Concrete;
using CoffeeProject.Mapping;
using CoffeeProject.RequestModel;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace CoffeeProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private DbContextOptions<DataBaseContext> options;
        public PersonsController()
        {
            options = new DbContextOptionsBuilder<DataBaseContext>()
                .UseInMemoryDatabase("CustomerDb")
                .Options;
            
        }

        [HttpGet]
        public IActionResult Get()
        {
            
            using (var context = new DataBaseContext(options))
            {
                var result = context.Customers.ToList().ToPersonInfo();
                return Ok(result);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] Order order)
        {
            order = JsonConvert.DeserializeObject<Order>(JsonConvert.SerializeObject(order));

            var validation = order.Validation();
            if (!validation.isValid)
                return BadRequest(validation.ValidationErrors);
            else
            {
                var dbModel = order.ToCustomerDbModel();
                
                using (var context = new DataBaseContext(options))
                {
                    var cof = context.Coffees.FirstOrDefault(c => c.Name.ToLower() == order.CoffeeName.ToLower());
                    if (context.Customers.Any(c => c.Id == dbModel.Id))
                    {
                      
                        return Ok("Hoş geldiniz borcunuz :"+ cof.UnitPrice);
                    }
                    else
                    {
                        
                        context.Customers.Add(dbModel);
                        context.SaveChanges();
                        return Ok("Hoş geldiniz borcunuz :" + cof.UnitPrice/2);
                    }
                   
                }
            }
            
        }

    }


       

}
