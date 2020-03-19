using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace assignment_WAD.Models
{
    public class Cart
    {
        public Dictionary<int, itemProduct> Items { get; set; }
        public double totalPrice => Items.Values.Sum(items => items.itemPrice);

        public Cart()
        {
            Items = new Dictionary<int, itemProduct>();
        }
        public void AddorUpdate(product product, int quanlity)
        {

            itemProduct cartitem = new itemProduct()
            {
                productId = product.productId,
                productName = product.productName,
                productPrice = product.productPrice,
                productImage = product.productImage,
                quanlity = quanlity
            };
            bool exist = Items.ContainsKey(product.productId);
            if (exist)
            {
                Debug.WriteLine("Items exist");
                //var existItem = Items[product.productId];
                //cartitem.quanlity += existItem.quanlity;
                var item = Items[product.productId];
                if (item.quanlity == 1 && product.productId== -1)
                {
                    removeItemProduct(product.productId);
                }
                else
                {
                    item.quanlity += quanlity;
                }
                
            }
            else
            {
                Items.Add(product.productId, cartitem);
                Debug.WriteLine("Items added");

            }
        }
        public bool removeItemProduct(int id)
        {
            try
            {
                if (Items.ContainsKey(id))
                {
                    Items.Remove(id);
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }

}