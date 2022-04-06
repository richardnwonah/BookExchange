namespace BookExchange.Api.DTOs
{
    public class RequestDTO
    {
        public Guid BookId { get; set; } 
        public Guid RequesterId{ get; set; }
        public Guid ApproverId { get; set; }
        public DateTime ReturnDate { get; set; }


    }
}