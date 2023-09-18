using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chancellery.Models
{
    public class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public Order Order { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int CountProduct { get; set; }

        public double PriceSum { get; set; }
        public double DiscountSum { get; set; }

    }
}
