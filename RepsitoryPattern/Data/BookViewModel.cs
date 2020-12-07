using System;

namespace RepsitoryPattern.Data
{
    public class Book
    {
        public int BookId { get; set; } 

        public string BookName { get; set; }
    
        public string Category { get; set; }

        public Author author { get; set; }
        public Guid AuthorId { get; set; }
    }
}