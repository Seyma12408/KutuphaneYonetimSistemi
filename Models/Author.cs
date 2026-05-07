using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KutuphaneYonetimSistemi.Models
{
    public class Author
    {
        [Key]
        public int AuthorId { get; set; }

        [Required(ErrorMessage = "Yazar adı zorunludur.")]
        [StringLength(50, ErrorMessage = "Yazar adı en fazla 50 karakter olabilir.")]
        [Display(Name = "Yazar Adı")]
        public string AuthorName { get; set; }

        [Required(ErrorMessage = "Yazar soyadı zorunludur.")]
        [StringLength(50, ErrorMessage = "Yazar soyadı en fazla 50 karakter olabilir.")]
        [Display(Name = "Yazar Soyadı")]
        public string AuthorSurname { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Doğum Tarihi")]
        public DateTime BirthDate { get; set; }

        public ICollection<Book>? Books { get; set; }
    }
}
