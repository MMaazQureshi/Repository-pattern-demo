using System;
using System.ComponentModel.DataAnnotations;

namespace RepsitoryPattern.Data
{
    public class Author
    {
        [Key]
        public Guid AuthorId { get; set; }

        public string AuthorName { get; set; }
        public string Reputation { get; set; }
    }
}