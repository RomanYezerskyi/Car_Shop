using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Shop.Data.Models
{
    public class ShopCart
    {
        private readonly AppDBContent appDBContent;

        public ShopCart(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }
        public string ShopCardId { get; set; }
        public List<ShopCartItems> listShopItems { get; set; }

        public static ShopCart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<AppDBContent>();
            string shopCardId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

            session.SetString("CartId", shopCardId);
            return new ShopCart(context) {ShopCardId = shopCardId};
        }

        public void AddToCart(Car car)
        {
            appDBContent.ShopCartItem.Add(new ShopCartItems
            {
                ShopCartId = ShopCardId,
                car = car,
                price = car.price
            });

            appDBContent.SaveChanges();
        }

        public List<ShopCartItems> GetShopItems()
        {
            return appDBContent.ShopCartItem.Where(c => c.ShopCartId == ShopCardId).Include(s => s.car).ToList();
        }
    }
}
