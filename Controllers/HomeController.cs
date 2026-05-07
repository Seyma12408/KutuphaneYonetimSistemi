using KutuphaneYonetimSistemi.Data;
using KutuphaneYonetimSistemi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace KutuphaneYonetimSistemi.Controllers
{
    public class HomeController : Controller
    {
        private readonly LibraryContext _context;

        // Dependency Injection ile DbContext alınıyor. Neden Entity Framework kullanıyoruz?
        // Çünkü SQL sorgularıyla uğraşmadan C# nesneleriyle (LINQ) veritabanı işlemlerini yapmak istiyoruz.
        public HomeController(LibraryContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            // Dashboard için istatistikleri çekiyoruz. LINQ Query kullanıldı.
            // View'a veri taşımak için ViewBag kullanıyoruz.
            ViewBag.TotalBooks = _context.Books.Count();
            ViewBag.TotalAuthors = _context.Authors.Count();
            ViewBag.TotalCategories = _context.Categories.Count();

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
