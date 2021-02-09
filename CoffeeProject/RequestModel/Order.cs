using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;
using CoffeeProject.Data.Context;
using CoffeeProject.Data.Entity.Abstract;
using Microsoft.EntityFrameworkCore;

namespace CoffeeProject.RequestModel
{
    public class Order
    {

        public string IdentityNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string CoffeeName { get; set; }

        public (bool isValid, List<string> ValidationErrors) Validation()
        {
            List<string> validateList = new List<string>();
            DbContextOptions<DataBaseContext> options = new DbContextOptionsBuilder<DataBaseContext>()
                .UseInMemoryDatabase("CustomerDb")
                .Options;
            using (var context = new DataBaseContext(options))
            {
                var entityList = context.Coffees.ToList();
                if (!entityList.Any(c => c.Name.ToLower() == CoffeeName.ToLower()))
                    validateList.Add("Böyle bir kahvemiz mevcut değil");
            }

            if (IdentityNumber.Length != 11)
                validateList.Add("Tc Kimlik Numaranız 11 Haneli olmalıdır");


            return (validateList.Count <= 0, validateList);
        }
    }
}
