using System.ComponentModel.DataAnnotations;

namespace LiMarket_V1._0._0.Models
{
    public class Image
    {
        [Key]
        public int Id { get; set; }

        public string Url { get; set; }

        public string Alt { get; set; }

        public Image()
        {
        }
    }
}