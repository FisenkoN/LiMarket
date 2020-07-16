using LiMarket_V1._0._0.Models;
using LiMarket_V1._0._0.Models.Repository;
using LiMarket_V1._0._0.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace LiMarket_V1._0._0.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        private UnitOfWork _unitOfWork;

        public AdminController()
        {
            _unitOfWork = new UnitOfWork();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreateAuthor()
        {
            Tool tool = new Tool();
            ViewBag.booksList = _unitOfWork.Books.GetAll();
            ViewBag.imagesList = new List<Image>(tool.GetImages());

            return View(new Author());
        }

        [HttpPost]
        public ActionResult CreateAuthor(Author author, int[] selectedBooks, int[] selectedImages)
        {
            if (selectedBooks != null)
            {
                foreach (var a in _unitOfWork.Books.GetAll().Where(a => selectedBooks.Contains(a.Id)))
                {
                    author.Books.Add(a);
                }
            }

            if (selectedImages != null)
            {
                foreach (var a in _unitOfWork.Images.GetAll().Where(a => selectedImages.Contains(a.Id)))
                {
                    author.Images.Add(a);
                }
            }

            author.AddDate = DateTime.Now;

            if (ModelState.IsValid)
            {
                _unitOfWork.Authors.Create(author);

                _unitOfWork.Save();

                return RedirectToAction("Index");
            }
            return View(author);
        }

        public ActionResult CreateBook()
        {
            Tool tool = new Tool();

            ViewBag.genresList = new SelectList(_unitOfWork.Genres.GetAll(), "Id", "Name");

            ViewBag.authorList = _unitOfWork.Authors.GetAll();

            ViewBag.imagesList = new List<Image>(tool.GetImages());

            return View(new Book());
        }

        [HttpPost]
        public ActionResult CreateBook(Book book, int[] selectedAuthors, int[] selectedImages)
        {
            if (selectedAuthors != null)
            {
                foreach (var a in _unitOfWork.Authors.GetAll().Where(a => selectedAuthors.Contains(a.Id)))
                {
                    book.Authors.Add(a);
                }
            }

            if (selectedImages != null)
            {
                foreach (var a in _unitOfWork.Images.GetAll().Where(a => selectedImages.Contains(a.Id)))
                {
                    book.Images.Add(a);
                }
            }

            book.AddDate = DateTime.Now;

            if (ModelState.IsValid)
            {
                _unitOfWork.Books.Create(book);

                _unitOfWork.Save();

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
                foreach (var a in _unitOfWork.Books.GetAll().Where(a => selectedBooks.Contains(a.Id)))
                {
                    genre.Books.Add(a);
                }
            }

            if (selectedImages != null)
            {
                foreach (var a in _unitOfWork.Images.GetAll().Where(a => selectedImages.Contains(a.Id)))
                {
                    genre.Images.Add(a);
                }
            }

            genre.AddDate = DateTime.Now;

            if (ModelState.IsValid)
            {
                _unitOfWork.Genres.Create(genre);

                _unitOfWork.Save();

                return RedirectToAction("Index");
            }

            return View(genre);
        }

        [HttpGet]
        public ActionResult EditBook(int id)
        {
            Tool tool = new Tool();
            var freeImages = new List<Image>(tool.GetImages());

            for (int i = 0; i < _unitOfWork.Books.Get(id).Images.Count; i++)
            {
                freeImages.Add(_unitOfWork.Books.Get(id).Images.ElementAt(i));
            }

            ViewBag.imagesList = freeImages;

            ViewBag.authorsList = _unitOfWork.Authors.GetAll();

            ViewBag.genresList = new SelectList(_unitOfWork.Genres.GetAll(), "Id", "Name");

            var book = _unitOfWork.Books.Get(id);

            if (book != null)
            {
                
                return View(book);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult EditBook(Book book, int[] selectedAuthors, int[] selectedImages)
        {
            var newBook = _unitOfWork.Books.Get(book.Id);

            newBook.GenreId = book.GenreId;

            newBook.Genre = _unitOfWork.Genres.Get(Convert.ToInt32(book.GenreId));

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
                foreach (var a in _unitOfWork.Authors.GetAll().Where(a => selectedAuthors.Contains(a.Id)))
                {
                    newBook.Authors.Add(a);
                }
            }

            if (selectedImages != null)
            {
                foreach (var a in _unitOfWork.Images.GetAll().Where(a => selectedImages.Contains(a.Id)))
                {
                    newBook.Images.Add(a);
                }
            }

            newBook.UpgradeDate = DateTime.Now;

            _unitOfWork.Books.Update(newBook);

            _unitOfWork.Save();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditAuthor(int id)
        {
            Tool tool = new Tool();
            var freeImages = new List<Image>(tool.GetImages());

            for (int i = 0; i < _unitOfWork.Authors.Get(id).Images.Count; i++)
            {
                freeImages.Add(_unitOfWork.Authors.Get(id).Images.ElementAt(i));
            }

            ViewBag.imagesList = freeImages;
            ViewBag.booksList = _unitOfWork.Books.GetAll();
            var author = _unitOfWork.Authors.Get(id);

            if (author != null)
            {
                return View(author);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult EditAuthor(Author author, int[] selectedBooks, int[] selectedImages)
        {
            var newAuthor = _unitOfWork.Authors.Get(author.Id);

            newAuthor.Description = author.Description;

            newAuthor.Populatity = author.Populatity;

            newAuthor.FirstName = author.FirstName;

            newAuthor.LastName = author.LastName;

            newAuthor.DateBirth = author.DateBirth;

            newAuthor.Books.Clear();

            newAuthor.Images.Clear();

            if (selectedBooks != null)
            {
                foreach (var a in _unitOfWork.Books.GetAll().Where(a => selectedBooks.Contains(a.Id)))
                {
                    newAuthor.Books.Add(a);
                }
            }

            if (selectedImages != null)
            {
                foreach (var a in _unitOfWork.Images.GetAll().Where(a => selectedImages.Contains(a.Id)))
                {
                    newAuthor.Images.Add(a);
                }
            }

            newAuthor.UpgradeDate = DateTime.Now;

            _unitOfWork.Authors.Update(newAuthor);

            _unitOfWork.Save();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditImage(int id)
        {
           
            var image = _unitOfWork.Images.Get(id);

            if (image != null)
            {

                return View(image);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult EditImage(Image image)
        {
            _unitOfWork.Images.Update(image);

            _unitOfWork.Save();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditGenre(int id)
        {
            Tool tool = new Tool();
            var freeBooks = new List<Book>(tool.GetBooks());

            for (int i = 0; i < _unitOfWork.Genres.Get(id).Books.Count; i++)
            {
                freeBooks.Add(_unitOfWork.Genres.Get(id).Books.ElementAt(i));
            }

            var freeImages = new List<Image>(tool.GetImages());

            for (int i = 0; i < _unitOfWork.Genres.Get(id).Images.Count; i++)
            {
                freeImages.Add(_unitOfWork.Genres.Get(id).Images.ElementAt(i));
            }

            ViewBag.booksList = freeBooks;

            ViewBag.imagesList = freeImages;

            var genre = _unitOfWork.Genres.Get(id);

            if (genre != null)
            {

                return View(genre);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult EditGenre(Genre genre, int[] selectedBooks, int[] selectedImages)
        {
            var newGenre = _unitOfWork.Genres.Get(genre.Id);

            newGenre.Name = genre.Name;

            newGenre.Description = genre.Description;

            newGenre.Popularity = genre.Popularity;

            newGenre.Books.Clear();

            newGenre.Images.Clear();

            if (selectedBooks != null)
            {
                foreach (var a in _unitOfWork.Books.GetAll().Where(a => selectedBooks.Contains(a.Id)))
                {
                    newGenre.Books.Add(a);
                }
            }

            if (selectedImages != null)
            {
                foreach (var a in _unitOfWork.Images.GetAll().Where(a => selectedImages.Contains(a.Id)))
                {
                    newGenre.Images.Add(a);
                }
            }

            newGenre.UpgradeDate = DateTime.Now;

            _unitOfWork.Genres.Update(newGenre);

            _unitOfWork.Save();

            return RedirectToAction("Index");
        }

        public ActionResult ReadAllBooks()
        {
            ViewBag.Genres = _unitOfWork.Genres.GetAll();

            var books = _unitOfWork.Books.GetAll();

            return View(books);
        }

        public ActionResult ReadAllAuthors()
        {
            var authors = _unitOfWork.Authors.GetAll();

            return View(authors);
        }

        public ActionResult ReadAllImages()
        {
            var images = _unitOfWork.Images.GetAll();

            return View(images);
        }

        public ActionResult ReadAllGenres()
        {
            var genres = _unitOfWork.Genres.GetAll();

            return View(genres);
        }

        public ActionResult InfoBook(int id)
        {
            var book = _unitOfWork.Books.Get(id);

            ViewBag.Genre = _unitOfWork.Genres.Get(Convert.ToInt32(book.GenreId));

            return View(book);
        }

        public ActionResult InfoAuthor(int id)
        {
            var author = _unitOfWork.Authors.Get(id);

            return View(author);
        }

        public ActionResult InfoImage(int id)
        {
            var image = _unitOfWork.Images.Get(id);

            return View(image);
        }

        [HttpGet]
        public ActionResult DeleteBook(int id)
        {
            var b = _unitOfWork.Books.Get(id);

            if (b == null)
            {
                return HttpNotFound();
            }

            return View(b);
        }

        [HttpPost, ActionName("DeleteBook")]
        public ActionResult DeleteBookConfirmed(int id)
        {
            var size = _unitOfWork.Books.Get(id).Images.Count;

            if (size != 0)
            {
                for (int i = 0; i < size; i++)
                {
                    _unitOfWork.Images.Delete(_unitOfWork.Books.Get(id).Images.First().Id);
                }
            }

            _unitOfWork.Books.Delete(id);

            _unitOfWork.Save();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult DeleteGenre(int id)
        {
            var genre = _unitOfWork.Genres.Get(id);

            if (genre == null)
            {
                return HttpNotFound();
            }

            return View(genre);
        }

        [HttpPost, ActionName("DeleteGenre")]
        public ActionResult DeleteGenreConfirmed(int id)
        {
            var books = _unitOfWork.Genres.Get(id).Books.ToList();

            foreach (var t in books)
            {
                var s = _unitOfWork.Books.Get(t.Id).Images.Count;

                if (s != 0)
                {
                    for (int i = 0; i < s; i++)
                    {
                        _unitOfWork.Images.Delete(_unitOfWork.Books.Get(t.Id).Images.First().Id);
                    }
                }

                _unitOfWork.Books.Delete(t.Id);

                _unitOfWork.Save();
            }
            var size = _unitOfWork.Genres.Get(id).Images.Count;

            if (size != 0)
            {
                for (int i = 0; i < size; i++)
                {
                    _unitOfWork.Images.Delete(_unitOfWork.Genres.Get(id).Images.First().Id);
                }
            }

            _unitOfWork.Genres.Delete(id);

            _unitOfWork.Save();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult DeleteAuthor(int id)
        {
            var author = _unitOfWork.Authors.Get(id);

            if (author == null)
            {
                return HttpNotFound();
            }

            return View(author);
        }

        [HttpPost, ActionName("DeleteAuthor")]
        public ActionResult DeleteAuthorConfirmed(int id)
        {
            var size = _unitOfWork.Authors.Get(id).Images.Count;

            if (size != 0)
            {
                for (int i = 0; i < size; ++i)
                {
                    _unitOfWork.Images.Delete(_unitOfWork.Authors.Get(id).Images.First().Id);
                }
            }

            _unitOfWork.Authors.Delete(id);

            _unitOfWork.Save();

            return RedirectToAction("Index");
        }

        public ActionResult InfoGenre(int id)
        {
            var genre = _unitOfWork.Genres.Get(id);

            return View(genre);
        }

        [HttpGet]
        public ActionResult DeleteImage(int id)
        {
            var image = _unitOfWork.Images.Get(id);

            if (image == null)
            {
                return HttpNotFound();
            }

            return View(image);
        }

        [HttpPost, ActionName("DeleteImage")]
        public ActionResult DeleteImageConfirmed(int id)
        {
            _unitOfWork.Images.Delete(id);

            _unitOfWork.Save();

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

            _unitOfWork.Images.Create(image);

            _unitOfWork.Save();

            return RedirectToAction("Index");
        }

    }
}