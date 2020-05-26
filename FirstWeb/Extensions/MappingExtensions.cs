using FirstWeb.Logic;
using FirstWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstWeb
{
    public static class MappingExtensions
    {
        public static UserModel ToModel(this Users u)
        {
            return new UserModel()
            {
                Id = u.Id,
                Email = u.Email,
                Name = u.Name,
                Phone = u.Phone,
                // + address
            };
        }
    }
}
