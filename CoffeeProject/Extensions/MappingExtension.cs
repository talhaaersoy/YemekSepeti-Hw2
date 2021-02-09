using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffeeProject.Data.Entity;
using CoffeeProject.Data.Entity.Abstract;
using CoffeeProject.Data.Entity.Concrete;
using CoffeeProject.RequestModel;

namespace CoffeeProject.Mapping
{
    public static class MappingExtension
    {
        public static Customer ToCustomerDbModel(this Order person)
        {
            return new Customer
                {
                    UserName = person.FirstName + "_" + person.LastName,
                    Id = person.IdentityNumber
                };
           
        }

        public static List<PersonInfo> ToPersonInfo(this List<Customer> persons)
        {
            List<PersonInfo> result = new List<PersonInfo>();
            

            for (int i = 0; i < persons.Count; i++)
            {
                string[] nameList = persons[i].UserName.Split("_");
                result.Add(new PersonInfo
                {
                    IdentityNumber = persons[i].Id,
                    FirstName = nameList[0],
                    LastName = nameList[1],

                });
            }

            return result;
        }


    }
}
