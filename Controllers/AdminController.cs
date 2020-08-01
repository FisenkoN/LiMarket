using LiMarket_V1._0._0.Models;
using LiMarket_V1._0._0.Models.Repository;
using LiMarket_V1._0._0.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace LiMarket_V1._0._0.Controllers
{

    public class AdminController : Controller
    {
        private IRepository<Book> bookRepository;
        private IRepository<Image> imageRepository;
        private IRepository<Author> authorRepository;
        private IRepository<Genre> genreRepository;

        public AdminController(IRepository<Book> book, IRepository<Image> image, IRepository<Author> author, IRepository<Genre> genre)
        {
            bookRepository = book;
            imageRepository = image;
            genreRepository = genre;
            authorRepository = author;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreateAuthor()
        {
            Tool tool = new Tool();
            ViewBag.booksList = bookRepository.GetAll();
            ViewBag.imagesList = new List<Image>(tool.GetImages());

            return View(new Author());
        }

        [HttpPost]
        public ActionResult CreateAuthor(Author author, int[] selectedBooks, int[] selectedImages)
        {
            if (selectedBooks != null)
            {
                foreach (var a in bookRepository.GetAll().Where(a => selectedBooks.Contains(a.Id)))
                {
                    author.Books.Add(a);
                }
            }

            if (selectedImages != null)
            {
                foreach (var a in imageRepository.GetAll().Where(a => selectedImages.Contains(a.Id)))
                {
                    author.Images.Add(a);
                }
            }

            author.AddDate = DateTime.Now;

            if (ModelState.IsValid)
            {
                authorRepository.Create(author);

                authorRepository.Save();

                return RedirectToAction("Index");
            }
            return View(author);
        }

        public ActionResult CreateBook()
        {
            Tool tool = new Tool();

            ViewBag.genresList = new SelectList(genreRepository.GetAll(), "Id", "Name");

            ViewBag.authorList = authorRepository.GetAll();

            ViewBag.imagesList = new List<Image>(tool.GetImages());

            return View(new Book());
        }

        [HttpPost]
        public ActionResult CreateBook(Book book, int[] selectedAuthors, int[] selectedImages)
        {
            if (selectedAuthors != null)
            {
                foreach (var a in authorRepository.GetAll().Where(a => selectedAuthors.Contains(a.Id)))
                {
                    book.Authors.Add(a);
                }
            }

            if (selectedImages != null)
            {
                foreach (var a in imageRepository.GetAll().Where(a => selectedImages.Contains(a.Id)))
                {
                    book.Images.Add(a);
                }
            }

            book.AddDate = DateTime.Now;

            if (ModelState.IsValid)
            {
                bookRepository.Create(book);

                bookRepository.Save();

                return RedirectToAction("Index");
            }
            return View(book);
        }

        public ActionResult CreateGenre()
        {
            Tool tool = new Tool();
            ViewBag.booksList = new List<Book>(tool.GetBooks());
            ViewBag.imagesList = new List<Image>(tool.GetImages());

            return View(new Genre());
        }

        [HttpPost]
        public ActionResult CreateGenre(Genre genre, int[] selectedBooks, int[] selectedImages)
        {
            if (selectedBooks != null)
            {
                foreach (var a in bookRepository.GetAll().Where(a => selectedBooks.Contains(a.Id)))
                {
                    genre.Books.Add(a);
                }
            }

            if (selectedImages != null)
            {
                foreach (var a in imageRepository.GetAll().Where(a => selectedImages.Contains(a.Id)))
                {
                    genre.Images.Add(a);
                }
            }

            genre.AddDate = DateTime.Now;

            if (ModelState.IsValid)
            {
                genreRepository.Create(genre);

                genreRepository.Save();

                return RedirectToAction("Index");
            }

            return View(genre);
        }

        [HttpGet]
        public ActionResult EditBook(int id)
        {
            Tool tool = new Tool();
            var freeImages = new List<Image>(tool.GetImages());

            for (int i = 0; i < bookRepository.Get(id).Images.Count; i++)
            {
                freeImages.Add(bookRepository.Get(id).Images.ElementAt(i));
            }

            ViewBag.imagesList = freeImages;

            ViewBag.authorsList = authorRepository.GetAll();

            ViewBag.genresList = new SelectList(genreRepository.GetAll(), "Id", "Name");

            var book = bookRepository.Get(id);

            if (book != null)
            {

                return View(book);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult EditBook(Book book, int[] selectedAuthors, int[] selectedImages)
        {
            var newBook = bookRepository.Get(book.Id);

            newBook.GenreId = book.GenreId;

            newBook.Genre = genreRepository.Get(Convert.ToInt32(book.GenreId));

            newBook.Name = book.Name;

            newBook.NumPages = book.NumPages;

            newBook.Popularity = book.Popularity;

            newBook.Price = book.Price;

            newBook.IsAvaible = book.IsAvaible;

            newBook.Year = book.Year;

            newBook.Description = book.Description;

            newBook.Authors.Clear();

            newBook.Images.Clear();

            if (selectedAuthors != null)
            {
                foreach (var a in authorRepository.GetAll().Where(a => selectedAuthors.Contains(a.Id)))
                {
                    newBook.Authors.Add(a);
                }
            }

            if (selectedImages != null)
            {
                foreach (var a in imageRepository.GetAll().Where(a => selectedImages.Contains(a.Id)))
                {
                    newBook.Images.Add(a);
                }
            }

            newBook.UpgradeDate = DateTime.Now;

            bookRepository.Update(newBook);

            bookRepository.Save();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditAuthor(int id)
        {
            Tool tool = new Tool();
            var freeImages = new List<Image>(tool.GetImages());

            for (int i = 0; i < authorRepository.Get(id).Images.Count; i++)
            {
                freeImages.Add(authorRepository.Get(id).Images.ElementAt(i));
            }

            ViewBag.imagesList = freeImages;
            ViewBag.booksList = bookRepository.GetAll();
            var author = authorRepository.Get(id);

            if (author != null)
            {
                return View(author);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult EditAuthor(Author author, int[] selectedBooks, int[] selectedImages)
        {
            var newAuthor = authorRepository.Get(author.Id);

            newAuthor.Description = author.Description;

            newAuthor.Populatity = author.Populatity;

            newAuthor.FirstName = author.FirstName;

            newAuthor.LastName = author.LastName;

            newAuthor.DateBirth = author.DateBirth;

            newAuthor.Books.Clear();

            newAuthor.Images.Clear();

            if (selectedBooks != null)
            {
                foreach (var a in bookRepository.GetAll().Where(a => selectedBooks.Contains(a.Id)))
                {
                    newAuthor.Books.Add(a);
                }
            }

            if (selectedImages != null)
            {
                foreach (var a in imageRepository.GetAll().Where(a => selectedImages.Contains(a.Id)))
                {
                    newAuthor.Images.Add(a);
                }
            }

            newAuthor.UpgradeDate = DateTime.Now;

            authorRepository.Update(newAuthor);

            authorRepository.Save();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditImage(int id)
        {

            var image = imageRepository.Get(id);

            if (image != null)
            {

                return View(image);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult EditImage(Image image)
        {
            imageRepository.Update(image);

            imageRepository.Save();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditGenre(int id)
        {
            Tool tool = new Tool();
            var y = tool.GetBooks();
            var freeBooks = new List<Book>(tool.GetBooks());

            for (int i = 0; i < genreRepository.Get(id).Books.Count; i++)
            {
                freeBooks.Add(genreRepository.Get(id).Books.ElementAt(i));
            }

            var freeImages = new List<Image>(tool.GetImages());

            for (int i = 0; i < genreRepository.Get(id).Images.Count; i++)
            {
                freeImages.Add(genreRepository.Get(id).Images.ElementAt(i));
            }

            ViewBag.booksList = freeBooks;

            ViewBag.imagesList = freeImages;

            var genre = genreRepository.Get(id);

            if (genre != null)
            {

                return View(genre);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult EditGenre(Genre genre, int[] selectedBooks, int[] selectedImages)
        {
            var newGenre = genreRepository.Get(genre.Id);

            newGenre.Name = genre.Name;

            newGenre.Description = genre.Description;

            newGenre.Popularity = genre.Popularity;

            newGenre.Books.Clear();

            newGenre.Images.Clear();

            if (selectedBooks != null)
            {
                foreach (var a in bookRepository.GetAll().Where(a => selectedBooks.Contains(a.Id)))
                {
                    newGenre.Books.Add(a);
                }
            }

            if (selectedImages != null)
            {
                foreach (var a in imageRepository.GetAll().Where(a => selectedImages.Contains(a.Id)))
                {
                    newGenre.Images.Add(a);
                }
            }

            newGenre.UpgradeDate = DateTime.Now;

            genreRepository.Update(newGenre);

            genreRepository.Save();

            return RedirectToAction("Index");
        }

        public ActionResult ReadAllBooks()
        {
            ViewBag.Genres = genreRepository.GetAll();

            var books = bookRepository.GetAll();

            return View(books);
        }

        public ActionResult ReadAllAuthors()
        {
            var authors = authorRepository.GetAll();

            return View(authors);
        }

        public ActionResult ReadAllImages()
        {
            var images = imageRepository.GetAll();

            return View(images);
        }

        public ActionResult ReadAllGenres()
        {
            var genres = genreRepository.GetAll();

            return View(genres);
        }

        public ActionResult InfoBook(int id)
        {
            var book = bookRepository.Get(id);

            ViewBag.Genre = genreRepository.Get(Convert.ToInt32(book.GenreId));

            return View(book);
        }

        public ActionResult InfoAuthor(int id)
        {
            var author = authorRepository.Get(id);

            return View(author);
        }

        public ActionResult InfoImage(int id)
        {
            var image = imageRepository.Get(id);

            return View(image);
        }

        [HttpGet]
        public ActionResult DeleteBook(int id)
        {
            var b = bookRepository.Get(id);

            if (b == null)
            {
                return HttpNotFound();
            }

            return View(b);
        }

        [HttpPost, ActionName("DeleteBook")]
        public ActionResult DeleteBookConfirmed(int id)
        {
            var size = bookRepository.Get(id).Images.Count;

            if (size != 0)
            {
                for (int i = 0; i < size; i++)
                {
                    imageRepository.Delete(bookRepository.Get(id).Images.First().Id);
                }
            }

            bookRepository.Delete(id);

            bookRepository.Save();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult DeleteGenre(int id)
        {
            var genre = genreRepository.Get(id);

            if (genre == null)
            {
                return HttpNotFound();
            }

            return View(genre);
        }

        [HttpPost, ActionName("DeleteGenre")]
        public ActionResult DeleteGenreConfirmed(int id)
        {
            var books = genreRepository.Get(id).Books.ToList();

            foreach (var t in books)
            {
                var s = bookRepository.Get(t.Id).Images.Count;

                if (s != 0)
                {
                    for (int i = 0; i < s; i++)
                    {
                        imageRepository.Delete(bookRepository.Get(t.Id).Images.First().Id);
                    }
                }

                bookRepository.Delete(t.Id);

                bookRepository.Save();
            }
            var size = genreRepository.Get(id).Images.Count;

            if (size != 0)
            {
                for (int i = 0; i < size; i++)
                {
                    imageRepository.Delete(genreRepository.Get(id).Images.First().Id);
                }
            }

            genreRepository.Delete(id);

            genreRepository.Save();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult DeleteAuthor(int id)
        {
            var author = authorRepository.Get(id);

            if (author == null)
            {
                return HttpNotFound();
            }

            return View(author);
        }

        [HttpPost, ActionName("DeleteAuthor")]
        public ActionResult DeleteAuthorConfirmed(int id)
        {
            var size = authorRepository.Get(id).Images.Count;

            if (size != 0)
            {
                for (int i = 0; i < size; ++i)
                {
                    imageRepository.Delete(authorRepository.Get(id).Images.First().Id);
                }
            }

            authorRepository.Delete(id);

            authorRepository.Save();

            return RedirectToAction("Index");
        }

        public ActionResult InfoGenre(int id)
        {
            var genre = genreRepository.Get(id);

            return View(genre);
        }

        [HttpGet]
        public ActionResult DeleteImage(int id)
        {
            var image = imageRepository.Get(id);

            if (image == null)
            {
                return HttpNotFound();
            }

            return View(image);
        }

        [HttpPost, ActionName("DeleteImage")]
        public ActionResult DeleteImageConfirmed(int id)
        {
            imageRepository.Delete(id);

            imageRepository.Save();

            return RedirectToAction("Index");
        }

        public ActionResult CreateImage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateImage(Image image)
        {
            if (!ModelState.IsValid) return View(image);

            imageRepository.Create(image);

            imageRepository.Save();

            return RedirectToAction("Index");
        }

    }
}