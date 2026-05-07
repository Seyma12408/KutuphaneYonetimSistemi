using KutuphaneYonetimSistemi.Data;
using KutuphaneYonetimSistemi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace KutuphaneYonetimSistemi.Controllers
{
    public class AuthorController : Controller
    {
        private readonly LibraryContext _context;

        public AuthorController(LibraryContext context)
        {
            _context = context;
        }

        // Yazar Listeleme (READ)
        public IActionResult Index()
        {
            var authors = _context.Authors.ToList();
            return View(authors);
        }

        // Yazar Ekleme Formu (CREATE - GET)
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Author author)
        {
            if (ModelState.IsValid)
            {
                _context.Authors.Add(author);
                _context.SaveChanges();
                TempData["Success"] = "Yazar başarıyla eklendi.";
                return RedirectToAction(nameof(Index));
            }
            return View(author);
        }

        // Yazar Güncelleme Formu (UPDATE - GET)
        public IActionResult Edit(int? id)
        {
            if (id == null) return NotFound();

            var author = _context.Authors.Find(id);
            if (author == null) return NotFound();

            return View(author);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Author author)
        {
            if (id != author.AuthorId) return NotFound();

            if (ModelState.IsValid)
            {
                _context.Authors.Update(author);
                _context.SaveChanges();
                TempData["Success"] = "Yazar başarıyla güncellendi.";
                return RedirectToAction(nameof(Index));
            }
            return View(author);
        }

        // Yazar Silme (DELETE - GET)
        public IActionResult Delete(int? id)
        {
            if (id == null) return NotFound();

            var author = _context.Authors.Find(id);
            if (author == null) return NotFound();

            return View(author);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var author = _context.Authors.Find(id);
            if (author != null)
            {
                _context.Authors.Remove(author);
                _context.SaveChanges();
                TempData["Success"] = "Yazar başarıyla silindi.";
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
