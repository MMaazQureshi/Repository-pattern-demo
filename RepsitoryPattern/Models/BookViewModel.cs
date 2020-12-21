using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace RepsitoryPattern.Data
{
    public class BookViewModel
    {
        public int BookId { get; set; }

        public string BookName { get; set; }

        public string Category { get; set; }
        public string AuthorName{ get; set; }
    }
}