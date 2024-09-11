using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectITI.Models;

namespace ProjectITI.Controllers
{
    public class ProductController : Controller
    {
        Context _context = new Context();
        public IActionResult Index()
        {
            var products = _context.Products.Include(e=>e.Category);
            return View(products);
        }
        [HttpGet]
        public IActionResult AddProduct()
        {
            ViewBag.Category = new SelectList(_context.Categories, "CategoryId", "Name");
            return View();
        }
        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "All Fields Required");
                return View();
            }
            _context.Products.Add(product);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        
        public IActionResult ViewDetails(int id)
        {
            var product = _context.Products.Include(p => p.Category).FirstOrDefault(p => p.ProductId == id);
            return View(product);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var product = _context.Products.Include(p => p.Category).FirstOrDefault(p => p.ProductId == id);
            ViewBag.Category = new SelectList(_context.Categories, "CategoryId", "Name");
            return View(product);
        }
        [HttpPost]
        public IActionResult Edit(Product product)
        {
            var oldProduct = _context.Products.FirstOrDefault(e => e.ProductId == product.ProductId);
            if (oldProduct == null)
            {
                return RedirectToAction("Index");
            }
            oldProduct.Title =product.Title;
            oldProduct.Quantity = product.Quantity;
            oldProduct.Description = product.Description;
            oldProduct.Price = product.Price;
            oldProduct.CategoryId = product.CategoryId;
            oldProduct.ImagePath = product.ImagePath;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        /*---------------------------------------------------------*/
        // Delete
        public IActionResult Delete(int id)
        {
            var product = _context.Products.FirstOrDefault(p => p.ProductId == id);
            if (product == null)
            {
                return RedirectToAction("Index");
            }
            _context.Products.Remove(product);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
