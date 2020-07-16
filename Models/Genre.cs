using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LiMarket_V1._0._0.Models
{
    public class Genre
    {   
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Image> Images { get; set; }

        public string Description { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime AddDate { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? UpgradeDate { get; set; }

        public virtual ICollection<Book> Books { get; set; }

        public int Popularity { get; set; }

        public Genre()
        {
            Images = new List<Image>();
            Books = new List<Book>();
            Popularity = 0;
        }

        public Genre AddBook(Book book)
        {
            this.Books.Add(book);
            return this;
        }
    }
}