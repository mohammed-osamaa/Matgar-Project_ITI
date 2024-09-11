using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectITI.Models;

namespace ProjectITI.Controllers
{
    public class CategoryController : Controller
    {
        Context _context = new Context();
        public IActionResult Index()
        {
            var category = _context.Categories;
            return View(category);
        }
        [HttpGet]
        public IActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddCategory(Category category)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "All Fields Required");
                return View();
            }
            _context.Categories.Add(category);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult ViewDetails(int id)
        {
            var category = _context.Categories.FirstOrDefault(p => p.CategoryId == id);
            return View(category);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var category = _context.Categories.FirstOrDefault(p => p.CategoryId == id);
            return View(category);
        }
        [HttpPost]
        public IActionResult Edit(Category C)
        {
            var oldcategory = _context.Categories.FirstOrDefault(e => e.CategoryId == C.CategoryId);
            if (oldcategory == null)
            {
                return RedirectToAction("Index");
            }
            oldcategory.Name = C.Name;
            oldcategory.Description = C.Description;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var category = _context.Categories.FirstOrDefault(p => p.CategoryId == id);
            if (category == null)
            {
                return RedirectToAction("Index");
            }
            _context.Categories.Remove(category);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
