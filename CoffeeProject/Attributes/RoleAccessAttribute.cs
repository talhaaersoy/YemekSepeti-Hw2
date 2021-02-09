using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeProject.Attributes
{
    [AttributeUsage(AttributeTargets.Class |
                    AttributeTargets.Constructor |
                    AttributeTargets.Method, AllowMultiple = true)]
    public class RoleAccessAttribute : Attribute
    {
        public UserRole UserRole { get; set; }

        public RoleAccessAttribute(UserRole role)
        {
            UserRole = role;
        }
    }
}
