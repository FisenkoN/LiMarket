using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LiMarket_V1._0._0.Models
{
    public class Book
    {   
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int? GenreId { get; set; }

        public Genre Genre { get; set; }

        public virtual ICollection<Author> Authors { get; set; }

        public virtual ICollection<Image> Images { get; set; }

        public int NumPages { get; set; }

        public int Year { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public int Popularity { get; set; }

        public bool IsAvaible { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime AddDate { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? UpgradeDate { get; set; }

        public Book()
        {
            Authors = new List<Author>();
            Images = new List<Image>();
            Popularity = 0;
        }
        
    }
}