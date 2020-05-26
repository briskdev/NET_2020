using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FirstWeb.Logic
{
    public static class UserManager
    {
        public static List<Users> GetAll()
        {
            using (var db = new DbContext())
            {
                // select Id, Name, Email, Phone from Users
                var users = db.Users.ToList();

                return users;
            }
        }
    }
}
