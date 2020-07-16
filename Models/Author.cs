using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LiMarket_V1._0._0.Models
{
    public  class Author
    {   
        [Key]
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public virtual ICollection<Book> Books { get; set; }

        public virtual ICollection<Image> Images { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime DateBirth { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime AddDate { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? UpgradeDate { get; set; }

        public int Populatity { get; set; }

        public string Description { get; set; }

        public Author()
        {
            Books = new List<Book>();
            Images = new List<Image>();
            Populatity = 0;
        }
    }
}