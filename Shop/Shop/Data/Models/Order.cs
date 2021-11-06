using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Shop.Data.Models
{
    public class Order
    {
        [BindNever]
        public int Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime orderTime { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
    }
}
