using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KutuphaneYonetimSistemi.Models
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }

        [Required(ErrorMessage = "Kitap adı zorunludur.")]
        [StringLength(200, ErrorMessage = "Kitap adı en fazla 200 karakter olabilir.")]
        [Display(Name = "Kitap Adı")]
        public string BookName { get; set; }

        [Required(ErrorMessage = "Sayfa sayısı zorunludur.")]
        [Range(1, 5000, ErrorMessage = "Sayfa sayısı 1 ile 5000 arasında olmalıdır.")]
        [Display(Name = "Sayfa Sayısı")]
        public int PageCount { get; set; }

        [Required(ErrorMessage = "Yayın yılı zorunludur.")]
        [Range(1000, 2100, ErrorMessage = "Geçerli bir yayın yılı giriniz.")]
        [Display(Name = "Yayın Yılı")]
        public int PublishYear { get; set; }

        [Required(ErrorMessage = "Stok miktarı zorunludur.")]
        [Range(0, 10000, ErrorMessage = "Stok miktarı negatif olamaz.")]
        [Display(Name = "Stok Miktarı")]
        public int Stock { get; set; }

        [Required(ErrorMessage = "Lütfen bir yazar seçiniz.")]
        [Display(Name = "Yazar")]
        public int AuthorId { get; set; }

        [Required(ErrorMessage = "Lütfen bir kategori seçiniz.")]
        [Display(Name = "Kategori")]
        public int CategoryId { get; set; }

        // Navigation properties
        [ForeignKey("AuthorId")]
        public Author? Author { get; set; }

        [ForeignKey("CategoryId")]
        public Category? Category { get; set; }
    }
}
