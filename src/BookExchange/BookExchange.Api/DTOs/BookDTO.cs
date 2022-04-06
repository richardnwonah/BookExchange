namespace BookExchange.Api.DTOs
{
    public class BookDTO
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
      //public IFormFile ImgFile { get; set; }
        public string ImgUrl { get; set; }
        public string ISBN { get; set; }
        public Guid CategoryId { get; set; }
        public DateTime YearOfPublication { get; set; }
        public string Author { get; set; }
        public Guid UserId { get; set; }
    
        
    }
}