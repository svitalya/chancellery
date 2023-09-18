using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chancellery.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }

        public double Price { get; set; }

        public double? Discount { get; set; }

        public int Count { get; set; }

        public double priceWithDiscount => Price - Price * (Discount ?? 0) / 100;

        public string discountStrign => Discount != null && Discount > 0 ? Discount.ToString()+"%" : "Нет";

        public string priceString => String.Format("{0:C2}", Price);
        public string priceWithDiscountString => String.Format("{0:C2}", priceWithDiscount);


    }
}
