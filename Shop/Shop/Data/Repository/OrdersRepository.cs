using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using Shop.Data.interfaces;
using Shop.Data.Models;

namespace Shop.Data.Repository
{
    public class OrdersRepository: IAllOrders
    {
        private readonly AppDBContent appDBContent;
        private readonly ShopCart shopCart;

        public OrdersRepository(AppDBContent appDBContent, ShopCart shopCart)
        {
            this.appDBContent = appDBContent;
            this.shopCart = shopCart;
        }
        public void CreateOrder(Order order)
        {
            order.orderTime = DateTime.Now;
            appDBContent.Order.Add(order);

            var items = shopCart.listShopItems;
            foreach (var item in items)
            {
                var orderDetail = new OrderDetail()
                {
                    CarId = item.car.id,
                    OrderId = order.Id,
                    Price = item.car.price,

                };
                appDBContent.OrderDetail.Add(orderDetail);
            }

            appDBContent.SaveChanges();
        }
    }
}
