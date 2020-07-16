using LiMarket_V1._0._0.Models;
using LiMarket_V1._0._0.Models.Repository;
using System.Collections.Generic;
using System.Linq;

namespace LiMarket_V1._0._0.Tools
{
    public class Tool
    {
        readonly UnitOfWork unit = new UnitOfWork();

        public  List<Image> GetImages()
        {
            var images = unit.Images.GetAll();
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
            var books = unit.Books.GetAll();
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
            var genreList = unit.Genres.GetAll();
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
            var genreList = unit.Genres.GetAll();
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

            var bookList = unit.Books.GetAll();
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

            var authorList = unit.Authors.GetAll();
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