using chancellery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace chancellery.Service
{
    public class CartPosition
    {
        private int _count;
        private Product _product;

        public Product product => _product;
        public int count => _count;


        public CartPosition(Product product)
        {
            this._product = product;
        }

        public void AddProduct()
        {
            _count++;
        }

        public void SetCount(int count)
        {
            _count = count;
        }

        public bool RemoveProduct()
        {
            _count--;
            return _count > 0;
        }

        public override string ToString()
        {
            return $"Product name = {_product.Name} Count = {_count}";
        }
    }

    internal class CartService
    {
        private Dictionary<int, CartPosition> _cart;

        public CartService()
        {
            this._cart = new Dictionary<int, CartPosition>();
        }

        public void Add(Product product)
        {
            CartPosition cp;
            if(!_cart.TryGetValue(product.ProductId, out cp))
            {
                cp = new CartPosition(product);
                _cart.Add(product.ProductId, cp);
            }

            cp.AddProduct();
        }

        public CartPosition getPosition(int productId)
        {
            return _cart[productId];
        }

        public override string ToString()
        {
            string str = "";

            foreach(KeyValuePair<int, CartPosition> position in _cart)
            {
                str += $"Position ID = {position.Key} {position.Value}\n";
            }

            return str;

        }

        public bool DeleteProduct(int productId)
        {
            CartPosition cp;
            if (_cart.TryGetValue(productId, out cp))
            {
                bool isSet = cp.RemoveProduct();
                if (!isSet)
                {
                    DeletePosition(productId);
                }

                return isSet;
            }
            return false;
        }

        public void DeletePosition(int productId)
        {
            _cart.Remove(productId);
        }

        public bool isSet()
        {
            return _cart.Count > 0; 
        }

        public void DataGridFill(ref DataGridView dataGrid)
        {
            dataGrid.Rows.Clear();     

            foreach (KeyValuePair<int, CartPosition> position in _cart)
            {
                CartPosition positionVal = position.Value;
                Product product = positionVal.product;
                double discount = product.Discount ?? 0;
                double priceWithDiscount = product.Price - product.Price * discount / 100;

                int n = dataGrid.Rows.Add(new string[]{
                    position.Key.ToString(),
                    product.Name,
                    product.Price.ToString(),
                    discount > 0 ? product.Discount.ToString() : "Нет",
                    Math.Round(priceWithDiscount, 2)
                        .ToString(),
                    positionVal.count.ToString(),
                    Math.Round(priceWithDiscount * positionVal.count, 2).ToString(),
                });
            }
        }
    }
}
