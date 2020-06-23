using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThucPham.Model.Models
{
    public class OrderTotal
    {
        public Order Order { get; set; }

        public IEnumerable<OrderDetail> OrderDetails { get; set; }
    }
}
