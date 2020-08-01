using LiMarket_V1._0._0.Models;
using LiMarket_V1._0._0.Models.Repository;
using Microsoft.Ajax.Utilities;
using System.Collections.Generic;
using System.Linq;

namespace LiMarket_V1._0._0.Tools
{
    public class Tool
    {
        private IRepository<Book> bookRepository;
        private IRepository<Image> imageRepository;
        private IRepository<Genre> genreRepository;
        private IRepository<Author> authorRepository;

        public Tool(IRepository<Book> book, IRepository<Image> image, IRepository<Author> author, IRepository<Genre> genre)
        {
            bookRepository = book;
            imageRepository = image;
            genreRepository = genre;
            authorRepository = author;
        }

        public  List<Image> GetImages()
        {
            var images = imageRepository.GetAll();
            var freeImages = new List<Image>();
            for (int i = 0; i < images.Count; i++)
            {
                if (IsFree(images.ElementAt(i)) == true)
                {
                    freeImages.Add(images.ElementAt(i));
                }
            }
            return freeImages;
        }

        public  List<Book> GetBooks()
        {
            var books = bookRepository.GetAll();
            var freeBooks = new List<Book>();
            for (int i = 0; i < books.Count; i++)
            {
                if (IsFree(books.ElementAt(i)) == true)
                {
                    freeBooks.Add(books.ElementAt(i));
                }
            }
            return freeBooks;
        }

        private  bool IsFree(Book book)
        {
            var genreList = genreRepository.GetAll();
            for (int i = 0; i < genreList.Count; i++)
            {
                var books = genreList.ElementAt(i).Books;
                var bCount = genreList.ElementAt(i).Books.Count;
                for (int j = 0; j < bCount; j++)
                {
                    if (books.ElementAt(j).Id == book.Id)
                    {
                        return false;
                    }    
                }          
            }            
            return true;
        }

        private  bool IsFree(Image image)
        {
            var genreList = genreRepository.GetAll();
            for (int i = 0; i < genreList.Count; i++)
            {
                var images = genreList.ElementAt(i).Images;
                var iCount = genreList.ElementAt(i).Images.Count;
                for (int j = 0; j < iCount; j++)
                {
                    if (images.ElementAt(j).Id == image.Id)
                    {
                        
                        return false;
                    }
                }
            }

            var bookList = bookRepository.GetAll();
            for (int i = 0; i < bookList.Count; i++)
            {
                var images = bookList.ElementAt(i).Images;
                var iCount = bookList.ElementAt(i).Images.Count;
                for (int j = 0; j < iCount; j++)
                {
                    if (images.ElementAt(j).Id == image.Id)
                    {
                        return false;
                    }
                }
            }

            var authorList = authorRepository.GetAll();
            for (int i = 0; i < authorList.Count; i++)
            {
                var images = authorList.ElementAt(i).Images;
                var iCount = authorList.ElementAt(i).Images.Count;
                for (int j = 0; j < iCount; j++)
                {
                    if (images.ElementAt(j).Id == image.Id)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

    }
}