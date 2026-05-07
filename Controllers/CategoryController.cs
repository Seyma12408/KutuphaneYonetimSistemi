using KutuphaneYonetimSistemi.Data;
using KutuphaneYonetimSistemi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace KutuphaneYonetimSistemi.Controllers
{
    public class CategoryController : Controller
    {
        private readonly LibraryContext _context;

        public CategoryController(LibraryContext context)
        {
            _context = context;
        }

        // Kategori Listeleme (READ)
        public IActionResult Index()
        {
            // Veritabanındaki tüm kategorileri List olarak View'a gönderiyoruz. (LINQ metodu: ToList())
            var categories = _context.Categories.ToList();
            return View(categories);
        }

        // Kategori Ekleme Formunu Getir (CREATE - GET)
        public IActionResult Create()
        {
            return View();
        }

        // Formdan Gelen Veriyi Kaydet (CREATE - POST)
        [HttpPost]
        [ValidateAntiForgeryToken] // CSRF saldırılarını önlemek için eklendi.
        public IActionResult Create(Category category)
        {
            // Validation (Doğrulama) Kontrolü. Model durumumuz (Data Annotations) geçerli mi?
            if (ModelState.IsValid)
            {
                _context.Categories.Add(category);
                _context.SaveChanges(); // Değişiklikleri veritabanına yansıtıyoruz.
                TempData["Success"] = "Kategori başarıyla eklendi.";
                return RedirectToAction(nameof(Index)); // İşlem bitince listeye yönlendir.
            }
            return View(category); // Geçersizse aynı sayfaya hatalarla birlikte geri dön.
        }

        // Kategori Güncelleme Formunu Getir (UPDATE - GET)
        public IActionResult Edit(int? id)
        {
            if (id == null) return NotFound();

            var category = _context.Categories.Find(id);
            if (category == null) return NotFound();

            return View(category);
        }

        // Güncellenmiş Veriyi Kaydet (UPDATE - POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Category category)
        {
            if (id != category.CategoryId) return NotFound();

            if (ModelState.IsValid)
            {
                _context.Categories.Update(category);
                _context.SaveChanges();
                TempData["Success"] = "Kategori başarıyla güncellendi.";
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        // Kategori Silme (DELETE - GET)
        public IActionResult Delete(int? id)
        {
            if (id == null) return NotFound();

            var category = _context.Categories.Find(id);
            if (category == null) return NotFound();

            return View(category);
        }

        // Silme İşlemini Onayla (DELETE - POST)
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var category = _context.Categories.Find(id);
            if (category != null)
            {
                _context.Categories.Remove(category);
                _context.SaveChanges();
                TempData["Success"] = "Kategori başarıyla silindi.";
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
