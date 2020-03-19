using assignment_WAD.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace assignment_WAD.Controllers
{
    public class CartController : Controller
    {
    private Model1 db = new Model1();
    private const String CartSeccsionName = "list_cart";
    // GET: Cart
    public ActionResult Index()
    {
            Cart cart = getListCart();
            ViewBag.listCart = cart;
            ViewBag.totalPrice = cart.totalPrice;
            ViewBag.categories = db.categories.ToList();
            return View("index", getListCart());
        }

    public ActionResult AddtoCart(String id)
    {
        Debug.WriteLine("id: " + id);
        int productId = Convert.ToInt32(id);
        Debug.WriteLine("productId: " + productId);
        product existProduct = db.products.FirstOrDefault(p => p.productId == productId);
        Debug.WriteLine(existProduct.productName);
        if (existProduct == null)
        {
            return new HttpNotFoundResult();
        }
        Cart listCart = getListCart();
        listCart.AddorUpdate(existProduct, 1);
        setListCart(listCart);
        return RedirectToAction("index", "Cart");
    }
        public ActionResult LesstoCart(String id)
        {
            Debug.WriteLine("id: " + id);
            int productId = Convert.ToInt32(id);
            Debug.WriteLine("productId: " + productId);
            product existProduct = db.products.FirstOrDefault(p => p.productId == productId);
            Debug.WriteLine(existProduct.productName);
            if (existProduct == null)
            {
                return new HttpNotFoundResult();
            }
            Cart listCart = getListCart();
            listCart.AddorUpdate(existProduct, -1);
            setListCart(listCart);
            return RedirectToAction("index", "Cart");
        }
        public ActionResult removeItem(String productId)
    {
        Debug.WriteLine("remove item with id=" + productId);
        int id = Convert.ToInt32(productId);
        Cart listCart = getListCart();
        listCart.removeItemProduct(id);
        setListCart(listCart);

            return RedirectToAction("index", "Cart");
        }
        //lưu thông tin giỏ hàng vào seccsion
    private void setListCart(Cart listCart)
    {
        Session[CartSeccsionName] = listCart;
    }
    private void clearListCart()
    {
        Session[CartSeccsionName] = null;
    }
    private Cart getListCart()
    {
        Cart listCart = null;
        if (Session[CartSeccsionName] != null)
        {
            try
            {
                listCart = Session[CartSeccsionName] as Cart;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
        if (listCart == null)
        {
            Debug.WriteLine("listCart = null");
            listCart = new Cart();
        }
        return listCart;
    }
    }
}