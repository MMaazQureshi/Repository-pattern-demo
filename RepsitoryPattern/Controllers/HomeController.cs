using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RepsitoryPattern.Data;
using RepsitoryPattern.Models;

namespace RepsitoryPattern.Controllers
{
    public class HomeController : Controller
    {
        public IBookRepository BookRepository;

        public IAuthorRepository AuthorRepository;

        public UnitOfWork UnitOfWork;

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger,IBookRepository bookRepository,IAuthorRepository authorRepository,UnitOfWork unitOfWork)
        {
            BookRepository = bookRepository;
            AuthorRepository = authorRepository;
           UnitOfWork = unitOfWork;
            _logger = logger;
        }

        public IActionResult Index()
        {
           var books = BookRepository.Get();
            return View(books);
        }

        public IActionResult AddBook([FromBody] BookViewModel book)

        {
            for (int i = 0; i < 10; i++)
            {
                var author = new Author()
                {
                    AuthorName = book.AuthorName
                };
                AuthorRepository.Create(author);
                Book book1 = new Book
                {
                    AuthorId = author.AuthorId,
                    BookName = book.BookName,
                    Category = book.Category
                };
                BookRepository.Create(book1);
            }
            
            UnitOfWork.Save();


            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
