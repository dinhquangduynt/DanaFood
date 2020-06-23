using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ThucPham.Model.Models;

namespace WebAPI.Models
{
    public class OrderViewModel
    {
        public Order Order { get; set; }

        public IEnumerable<OrderDetail> OrderDetails { get; set; }
    }
}