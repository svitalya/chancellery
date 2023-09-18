using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chancellery.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public PointDelivery PointDelivery { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public User User { get; set; }
        public DateTime CreateDate {  get; set; }
        public double PriceSum {  get; set; }
        public double DiscountSum {  get; set; }
    }
}
