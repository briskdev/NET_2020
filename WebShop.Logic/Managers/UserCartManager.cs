using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebShop.Logic.DB;

namespace WebShop.Logic
{
    public class UserCartManager
    {
        public static void Create(int userId, int itemId)
        {
            using(var db = new DbContext())
            {
                db.UserCart.Add(new UserCart()
                {
                    UserId = userId,
                    ItemId = itemId,
                });
                db.SaveChanges();
            }
        }

        public static List<UserCart> GetByUser(int userId)
        {
            using (var db = new DbContext())
            {
                // atlasa lietotāja groza ierakstus
                // var userCart = db.UserCart.Where(c => c.UserId == userId).ToList();

                // katram groza ierakstam atlasa atbilstošā 'Item' datus
                // TODO: izmantot SQL join
                // foreach(var item in userCart)
                // {
                //    item.Item = db.Items.Find(item.ItemId);
                // }

                var userCart = db.UserCart.Where(c => c.UserId == userId)
                    .Join(db.Items, c => c.ItemId, i => i.Id, (c, i) => new UserCart()
                    {
                        Item = i
                    }).ToList();

                // select * from UserCart where UserId = @userId
                // select * from Items where Id = @ItemId1
                // select * from Items where Id = @ItemId2
                // select * from Items where Id = @ItemId3

                // SQL JOIN
                // select * from UserCart c, Items i 
                // where c.UserId = @userId AND i.Id = c.ItemId

                return userCart;
            }
        }
    }
}
