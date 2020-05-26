using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FirstWeb.Logic
{
    public class UserManager
    {
        public static List<Users> GetAll()
        {
            using(var db = new DbContext())
            {
                return db.Users.OrderBy(u => u.Name).ToList();
            }
        }

        public static Users Get(int id)
        {
            using (var db = new DbContext())
            {
                return db.Users.Find(id);
            }
        }

        public static void Create(string name, string email, string phone)
        {
            using (var db = new DbContext())
            {
                db.Users.Add(new Users()
                {
                    Email = email,
                    Name = name,
                    Phone = phone,
                });

                db.SaveChanges();
            }
        }
    }
}
