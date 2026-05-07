using KutuphaneYonetimSistemi.Data;
using KutuphaneYonetimSistemi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace KutuphaneYonetimSistemi.Controllers
{
    public class BookController : Controller
    {
        private readonly LibraryContext _context;

        public BookController(LibraryContext context)
        {
            _context = context;
        }

        // Kitap Listeleme ve Arama Sistemi (READ & SEARCH)
        public IActionResult Index(string searchString)
        {
            // Eager Loading: Kitapları çekerken Yazar ve Kategori bilgilerini de JOIN yaparak çekiyoruz (.Include)
            var booksQuery = _context.Books
                                     .Include(b => b.Author)
                                     .Include(b => b.Category)
                                     .AsQueryable();

            // Arama Sistemi (LINQ)
            // Öğretmen sorusu: Arama nasıl çalışıyor?
            // Cevap: View'dan gelen searchString parametresi doluysa, LINQ Where metodu ile BookName veya AuthorName içerisinde geçenleri filtreliyoruz.
            if (!string.IsNullOrEmpty(searchString))
            {
                booksQuery = booksQuery.Where(b => b.BookName.Contains(searchString) 
                                                || b.Author.AuthorName.Contains(searchString)
                                                || b.Author.AuthorSurname.Contains(searchString));
            }

            return View(booksQuery.ToList());
        }

        // Kitap Ekleme (CREATE - GET)
        public IActionResult Create()
        {
            // Dropdown için Yazar ve Kategori listelerini ViewBag ile gönderiyoruz
            // Öğretmen sorusu: View'a Dropdown verisi nasıl taşındı?
            // Cevap: SelectList nesnesi oluşturup ViewBag içerisine atarak View tarafında asp-items ile kullandık.
            ViewBag.Authors = new SelectList(_context.Authors, "AuthorId", "AuthorName");
            ViewBag.Categories = new SelectList(_context.Categories, "CategoryId", "CategoryName");
            return View();
        }

        // Kitap Ekleme (CREATE - POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Book book)
        {
            if (ModelState.IsValid)
            {
                _context.Books.Add(book);
                _context.SaveChanges();
                TempData["Success"] = "Kitap başarıyla eklendi.";
                return RedirectToAction(nameof(Index));
            }
            
            // Eğer model hatalıysa dropdownlar kaybolmasın diye tekrar dolduruyoruz.
            ViewBag.Authors = new SelectList(_context.Authors, "AuthorId", "AuthorName", book.AuthorId);
            ViewBag.Categories = new SelectList(_context.Categories, "CategoryId", "CategoryName", book.CategoryId);
            return View(book);
        }

        // Kitap Güncelleme (UPDATE - GET)
        public IActionResult Edit(int? id)
        {
            if (id == null) return NotFound();

            var book = _context.Books.Find(id);
            if (book == null) return NotFound();

            ViewBag.Authors = new SelectList(_context.Authors, "AuthorId", "AuthorName", book.AuthorId);
            ViewBag.Categories = new SelectList(_context.Categories, "CategoryId", "CategoryName", book.CategoryId);
            return View(book);
        }

        // Kitap Güncelleme (UPDATE - POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Book book)
        {
            if (id != book.BookId) return NotFound();

            if (ModelState.IsValid)
            {
                _context.Books.Update(book);
                _context.SaveChanges();
                TempData["Success"] = "Kitap başarıyla güncellendi.";
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Authors = new SelectList(_context.Authors, "AuthorId", "AuthorName", book.AuthorId);
            ViewBag.Categories = new SelectList(_context.Categories, "CategoryId", "CategoryName", book.CategoryId);
            return View(book);
        }

        // Kitap Silme (DELETE - GET)
        public IActionResult Delete(int? id)
        {
            if (id == null) return NotFound();

            var book = _context.Books
                               .Include(b => b.Author)
                               .Include(b => b.Category)
                               .FirstOrDefault(m => m.BookId == id);
                               
            if (book == null) return NotFound();

            return View(book);
        }

        // Kitap Silme Onay (DELETE - POST)
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var book = _context.Books.Find(id);
            if (book != null)
            {
                _context.Books.Remove(book);
                _context.SaveChanges();
                TempData["Success"] = "Kitap başarıyla silindi.";
            }
            return RedirectToAction(nameof(Index));
        }
        
        // Kitap Detayları (DETAILS)
        public IActionResult Details(int? id)
        {
            if (id == null) return NotFound();

            var book = _context.Books
                               .Include(b => b.Author)
                               .Include(b => b.Category)
                               .FirstOrDefault(m => m.BookId == id);

            if (book == null) return NotFound();

            return View(book);
        }
    }
}
