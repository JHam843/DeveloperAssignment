using DeveloperAssignment.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DeveloperAssignment.Controllers
{
    public class ChildrenController : Controller
    {
        private readonly ChildrenContext _context;

        public ChildrenController(ChildrenContext context)
        {
            _context = context;
        }

        // List all children
        public IActionResult Index()
        {
            var children = _context.Children.ToList();
            return View(children);
        }

        // Show details of a specific child
        public IActionResult Details(int id)
        {
            var child = _context.Children.FirstOrDefault(c => c.Id == id);
            if (child == null)
            {
                return NotFound();
            }
            return View(child);
        }

        // Show create form
        public IActionResult Create()
        {
            return View();
        }

        // Handle create form submission
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Child child)
        {
            if (ModelState.IsValid)
            {
                _context.Children.Add(child);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(child);
        }

        // Show edit form
        public IActionResult Edit(int id)
        {
            var child = _context.Children.FirstOrDefault(c => c.Id == id);
            if (child == null)
            {
                return NotFound();
            }
            return View(child);
        }

        // Handle edit form submission
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Child child)
        {
            if (id != child.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(child);
                    _context.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    ModelState.AddModelError("", "Unable to save changes due to concurrency conflict.");
                }
            }
            return View(child);
        }


        // Show delete confirmation
        public IActionResult Delete(int id)
        {
            var child = _context.Children.FirstOrDefault(c => c.Id == id);
            if (child == null)
            {
                return NotFound();
            }
            return View(child);
        }

        // Handle delete confirmation
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var child = _context.Children.FirstOrDefault(c => c.Id == id);
            if (child == null)
            {
                return NotFound();
            }

            _context.Children.Remove(child);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
