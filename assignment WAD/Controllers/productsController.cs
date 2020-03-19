using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using assignment_WAD.Models;

namespace assignment_WAD.Controllers
{
    public class productsController : Controller
    {
        private Model1 db = new Model1();
        public ActionResult Category(int? id)
        {
            if (id != 0)
            {
                category category_ = null;
                category_ = db.categories.Find(id);
                if (category_!= null)
                {
                    ViewBag.TieuDe = category_.categoryName;

                }
                var model = db.products.Where(p => p.categoryId == id);
                List<product> list_product = model.ToList();
                ViewBag.product = list_product;
                ViewBag.categories = db.categories.ToList();
                return View(db.categories.ToList());
            }
            return HttpNotFound();
        }
        public ActionResult Search(int CategoryId = 0, String Keywords = "")
        {          
            if (CategoryId != 0)
            {
                var model = db.products
                    .Where(p => p.categoryId == CategoryId);
                List<product> list_product = model.ToList();
                return View(db.categories.ToList());
            }
            else if (Keywords != "")
            {
                var model = db.products
                    .Where(p => p.productName.Contains(Keywords));
                List<product> list_product = model.ToList();
                ViewBag.product = list_product;
                return View(db.categories.ToList());
            }
            ViewBag.categories = db.categories.ToList();
            return View(db.products);
        }
        // GET: products
        public ActionResult Index()
        {
            ViewBag.categories = db.categories.ToList();
            var products = db.products.Include(p => p.category);
            return View(products.ToList());
        }

        // GET: products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            product product = db.products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: products/Create
        public ActionResult Create()
        {
            ViewBag.categoryId = new SelectList(db.categories, "categoryId", "categoryName");
            return View();
        }

        // POST: products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "productId,productName,productDescription,productImage,productPrice,categoryId")] product product)
        {
            if (ModelState.IsValid)
            {
                db.products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.categoryId = new SelectList(db.categories, "categoryId", "categoryName", product.categoryId);
            return View(product);
        }

        // GET: products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            product product = db.products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.categoryId = new SelectList(db.categories, "categoryId", "categoryName", product.categoryId);
            return View(product);
        }

        // POST: products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "productId,productName,productDescription,productImage,productPrice,categoryId")] product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.categoryId = new SelectList(db.categories, "categoryId", "categoryName", product.categoryId);
            return View(product);
        }

        // GET: products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            product product = db.products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            product product = db.products.Find(id);
            db.products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        public ActionResult Detail(int id)
        {
            var model = db.products.Find(id);

            return View(model);
        }
    }
}

