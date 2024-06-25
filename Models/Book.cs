using System.ComponentModel.DataAnnotations;

namespace Book.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [StringLength(100)]
        public string Title { get; set; }

        [StringLength(100)]

        public string Author { get; set; }
        public string Description { get; set; }
        public string Genre { get; set; }
        public DateTime PublishedDate { get; set; }
    }
}
