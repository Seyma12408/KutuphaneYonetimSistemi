using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KutuphaneYonetimSistemi.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Kategori adı zorunludur.")]
        [StringLength(100, ErrorMessage = "Kategori adı en fazla 100 karakter olabilir.")]
        [Display(Name = "Kategori Adı")]
        public string CategoryName { get; set; }

        public ICollection<Book>? Books { get; set; }
    }
}
