using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStoreAli.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required, Range(minimum: 5, maximum: 10000)]
        public int? Price { get; set; } = null;
        [Required(ErrorMessage ="Select the Category")]

        public SelectList Categories { get; set; } = new SelectList(new List<string> { "Thriller", "Comedy", "Action" });
    
        [Required]
        public string Category { get; set; }

        public int AuthorId { get; set; }

        public Author Author_test { get; set; }

        [Required]
        public string Author { get; set; }
        [Required (ErrorMessage ="Select the Availability")]
        public bool? Available { get; set; }

    }
}