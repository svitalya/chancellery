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

        public double resultPrice => Math.Round(this._count * this._product.priceWithDiscount, 2);
        public string resultPriceString => String.Format("{0:C2}", resultPrice);


        public CartPosition(Product product)
        {
            this._product = product;
            this._count = 0;
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


        public bool Add(Product product)
        {
            if(product.Count <= 0) return false;

            CartPosition cp = getOrCreatePosition(product);

            if(cp.count + 1 <= product.Count)
            {
                cp.AddProduct();
                return true;
            }
            else
            {
                return false;
            }
            
        }

        public bool SetCount(Product product, int count)
        {
            if (product.Count <= 0) return false;

            CartPosition cp = getOrCreatePosition(product);
            if (count == 0)
            {
                DeletePosition(product.ProductId);
                return true;
            }
            else if (count <= product.Count)
            {
                cp.SetCount(count);
                return true;
            }
            else
            {
                return false;
            }
        }

        public CartPosition getPosition(int productId)
        {
            try
            {
                return _cart[productId];
            }catch(KeyNotFoundException)
            {
                return null;
            }
            
        }

        private CartPosition getOrCreatePosition(Product product)
        {
            CartPosition cartPosition = getPosition(product.ProductId);

            if(cartPosition == null)
            {
                cartPosition = new CartPosition(product);
                _cart.Add(product.ProductId, cartPosition);
            }

            return cartPosition;
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

        public void clearCart()
        {
            _cart.Clear();
        }

        public void DataGridFill(ref DataGridView dataGrid)
        {
            dataGrid.Rows.Clear();     

            foreach (KeyValuePair<int, CartPosition> position in _cart)
            {
                CartPosition positionVal = position.Value;
                Product product = positionVal.product;

                dataGrid.Rows.Add(new string[]{
                    position.Key.ToString(),
                    product.Name,
                    product.priceString,
                    product.discountStrign,
                    product.priceWithDiscountString,
                    positionVal.count.ToString(),
                    positionVal.resultPriceString,
                });
            }
        }
    }
}
