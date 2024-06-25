using System.ComponentModel.DataAnnotations;

namespace BookProject.DTOs
{
    public class GetBooks
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public string Genre { get; set; }
        public DateTime PublishedDate { get; set; }
    }
}
