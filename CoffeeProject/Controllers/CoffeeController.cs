using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffeeProject.Attributes;
using CoffeeProject.Data.Context;
using CoffeeProject.Data.Entity.Concrete;
using Microsoft.EntityFrameworkCore;

namespace CoffeeProject.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [RoleAccess(UserRole.Director)]
    public class CoffeeController : ControllerBase
    {
        private DbContextOptions<DataBaseContext> options;
        private readonly InMemoryCoffees _inMemory;

        public CoffeeController()
        {
            options = new DbContextOptionsBuilder<DataBaseContext>()
                .UseInMemoryDatabase("CustomerDb")
                .Options;
            _inMemory = InMemoryCoffees.Instance;

        }

        [HttpGet]
        public IActionResult Get()
        {

            using (var context = new DataBaseContext(options))
            {
                var result = context.Coffees.ToList();
                return Ok(result);
            }
        }


        [HttpPost]
        public IActionResult Post([FromBody] Coffee coffee)
        {
            var typeInfo = typeof(CoffeeController);
            RoleAccessAttribute[] roleAccess = typeInfo
                    .GetCustomAttributes(typeof(RoleAccessAttribute), true)
                     as RoleAccessAttribute[];

            if (roleAccess.All(ra =>
                ra.UserRole.ToString().ToLower()
                != coffee.CreatedBy.ToLower()))
            {
                return BadRequest("Kullanıcı yeterli yetkiye sahip değil");
            }
            else
            {
                using (var context = new DataBaseContext(options))
                {
                    if (context.Coffees.Any(c => c.Id == coffee.Id))
                    {
                        context.Coffees.Update(coffee);
                        context.SaveChanges();
                        return Ok("Kahve bilgileri güncellendi");
                    }
                    else
                    {
                        context.Coffees.Add(coffee);
                        context.SaveChanges();
                        return Ok("Kahve menüye başarıyla eklendi");
                    }
                }
            }
        }

    }
}
