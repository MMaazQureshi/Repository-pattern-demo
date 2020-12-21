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
        public IBookRepository _bookRepository;

        public IAuthorRepository _authorRepository;
        public IPublisherRepository _publisherRepository;

        public UnitOfWork UnitOfWork;

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger,IBookRepository bookRepository,IAuthorRepository authorRepository,UnitOfWork unitOfWork, IPublisherRepository publisherRepository)
        {
            _bookRepository = bookRepository;
            _authorRepository = authorRepository;
           UnitOfWork = unitOfWork;
            _publisherRepository = publisherRepository;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var books = from book in _bookRepository.Get() join authors in _authorRepository.Get() 
                        
                        on book.AuthorId equals authors.AuthorId
                        join publishers in _publisherRepository.Get() on book.PublisherId equals publishers.Id select book ;

            foreach (var item in books)
            {
                BookViewModel model = new BookViewModel()
                {
                    BookName = item.BookName,
                    AuthorName = item.author.AuthorName,
                    Category = item.Category,
                };
            }
            
            return View(books);
        }

        public IActionResult AddBook([FromBody] BookViewModel book)

        {
            
                var author = new Author()
                {
                    AuthorName = book.AuthorName
                };
                _authorRepository.Create(author);
                Book book1 = new Book
                {
                    AuthorId = author.AuthorId,
                    BookName = book.BookName,
                    Category = book.Category
                };
                _bookRepository.Create(book1);
            
            
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
