using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace RepsitoryPattern.Data
{
    public class Book
    {
        public int BookId { get; set; } 

        public string BookName { get; set; }
    
        public string Category { get; set; }

        public Author author { get; set; }
        [ForeignKey("Id")]
        public Guid AuthorId { get; set; }
        [ForeignKey("Id")]
        public int PublisherId { get; internal set; }
        public Publisher Publisher { get; set; }

    }
}