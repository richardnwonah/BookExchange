namespace BookExchange.Core.Models
{
    public class Book
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
      //public IFormFile ImgFile { get; set; }
        public string ImgUrl { get; set; }
        public string ISBN { get; set; }
        public Guid CategoryId { get; set; }
        public Category? Category { get; set; }
        public DateTime YearOfPublication { get; set; }
        public string Author { get; set; }
        public Guid UserId { get; set; }
        public User? Owner { get; set; }
        public string Description { get; set; } = "Available";
        
    }
}